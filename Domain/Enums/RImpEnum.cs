using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum RImpEnum : short
{
    [Display(Description = "No Risk", Order = 1)] NoRisk = 0,
    [Display(Description = "Not Very", Order = 2)] NotVery = 1,
    [Display(Description = "Somewhat", Order = 3)] Somewhat = 2,
    [Display(Description = "Very", Order = 4)] Very = 3,
}
