using Core.Contexts;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core;

public class PersonalFinancalInquiryRepository : IInquiryActionRepository
{
    public Type SupportedType => typeof(PersonalFinancalInquiry);

    public Task CancelAsync(Inquiry inquiry)
    {
        throw new NotImplementedException();
    }

    public Task CompleteAsync(Inquiry inquiry)
    {
        throw new NotImplementedException();
    }
}
