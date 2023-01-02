using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum AbortionTypeEnum : short
{
    [Display(Description = "Chemical", Order = 1)] Chemical = 1,
    [Display(Description = "Surgical", Order = 2)] Surgical = 2,
}
