using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum ResultEnum : short
{
    [Display(Description = "Positive", Order = 1)] Positive = 0,
    [Display(Description = "Negative", Order = 2)] Negative = 1,
    [Display(Description = "Inconclusive", Order = 3)] Inconclusive = 2,
}
