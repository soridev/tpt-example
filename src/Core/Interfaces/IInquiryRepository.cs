using Core.Contexts;

namespace Core.Interfaces;

public interface IInquiryRepository
{
    public Task<IEnumerable<Inquiry>> GetInquiriesAsync();
    public Task<IEnumerable<Inquiry>> GetInquiriesByPersonId(Guid personId);
}
