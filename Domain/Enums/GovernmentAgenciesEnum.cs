using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum GovernmentAgenciesEnum : short
{
    [Display(Description = "Welfare", Order = 1)] Welfare = 0,
    [Display(Description = "Medicaid", Order = 2)] Medicaid = 1,
    [Display(Description = "WIC", Order = 3)] WIC = 2,
    [Display(Description = "Department of Child and Family Services", Order = 4)] ChildFamilyServices = 3,
    [Display(Description = "Nevada 211", Order = 5)] Nevada211 = 4,
}
