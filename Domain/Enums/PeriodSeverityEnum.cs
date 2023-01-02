using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum PeriodSeverityEnum : short
{
    [Display(Description = "Mild", Order = 1)] Mild = 0,
    [Display(Description = "Moderate", Order = 2)] Moderate = 1,
    [Display(Description = "Heavy", Order = 3)] Heavy = 2,
}
