using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum CrampsSeverityEnum : short
{
    [Display(Description = "Mild", Order = 0)] Mild = 0,
    [Display(Description = "Moderate", Order = 1)] Moderate = 1,
    [Display(Description = "Heavy", Order = 2)] Heavy = 2,
}
