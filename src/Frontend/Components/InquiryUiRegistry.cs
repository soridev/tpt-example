using Core.Contexts;
using Frontend.Components.Pages;

namespace Frontend.Components;

public static class InquiryUiRegistry
{
    private static readonly Dictionary<Type, Type> _mappings = new()
    {
        { typeof(PersonalMedicalInquiry), typeof(PersonalMedicalInquiryDetails) },
        { typeof(CompanyMedicalInquiry), typeof(CompanyMedicalInquiryDetails) },
        { typeof(PersonalFinancalInquiry), typeof(PersonalFinancalInquiryDetails) },
        { typeof(CompanyFinancalInquiry), typeof(CompanyFinancalInquiryDetails) }
        
        // Add new mappings here as you add new inquiry types
    };

    public static Type GetComponentType(Inquiry inquiry)
        => _mappings.GetValueOrDefault(inquiry.GetType(), typeof(NotFound));
}
