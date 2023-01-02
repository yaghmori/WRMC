using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum ProofResidenceEnum : short
{
    [Display(Description = "Current utility bill with your name and address", Order = 1)] BillNameAddress = 0,
    [Display(Description = "Current correspondence from a Clark County agency", Order = 2)] CorrespondenceClarkCountyAgency = 1,
    [Display(Description = "Current correspondence from a Government agency (i.e. Social Security)", Order = 3)] CorrespondenceGovernmentAgency = 2,
    [Display(Description = "Signed lease agreement with your name and the address of the residence", Order = 4)] SignedLeaseAgreement = 3,
    [Display(Description = "Mortgage statement with your name and the address of the residence", Order = 5)] MortgageStatement = 4,
    [Display(Description = "Letter of residency from homeowner or landlord", Order = 6)] LetterOfResidencyFromLandlord = 5,
    [Display(Description = "Pay stub with current home address", Order = 7)] PayStubWithHomeAddress = 6,
}
