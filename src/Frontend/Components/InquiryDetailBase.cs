using Core.Contexts;
using Microsoft.AspNetCore.Components;

namespace Frontend.Components;

public abstract class InquiryDetailBase<T> : ComponentBase where T : Inquiry
{
    [Parameter] public required Inquiry Data { get; set; }
    protected T Inquiry => (T)Data;
}
