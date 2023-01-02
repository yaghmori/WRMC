using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum AbortionRiskEnum : short
{
    [Display(Description = "Yes", Order = 1)] Yes = 0,
    [Display(Description = "No", Order = 2)] No = 1,
    [Display(Description = "Maybe", Order = 3)] Maybe = 2,
}
