using Core.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces;

public interface IInquiryActionRepository
{
    Type SupportedType { get; }
    Task CancelAsync(Inquiry inquiry);
    Task CompleteAsync(Inquiry inquiry);
}
