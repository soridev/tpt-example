using Core.Contexts;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core;

public class InquiryRepository(TptContext context) : IInquiryRepository
{
    public async Task<IEnumerable<Inquiry>> GetInquiriesAsync()
    {
        return await context.Inquiries.ToListAsync();
    }

    public async Task<IEnumerable<Inquiry>> GetInquiriesByPersonId(Guid personId)
    {
        var queries = context.Model.GetEntityTypes()
            .Where(t => typeof(IPersonalInquiry).IsAssignableFrom(t.ClrType))
            .Select(t =>
            {
                var method = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes)!
                                       .MakeGenericMethod(t.ClrType);
                return (IQueryable<IPersonalInquiry>)method.Invoke(context, null)!;
            });

        List<Inquiry> result = new();
        foreach (var query in queries)
        {
            var filtered = query.Where(x => x.PersonId == personId).Cast<Inquiry>();
            result.AddRange(await filtered.ToListAsync());
        }
        
        return result;
    }
}