using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum MaritalEnum : short
{
    [Display(Description = "Single/Never Married", Order = 1)] SingleNeverMarried = 0,
    [Display(Description = "Living Together/Unmarried", Order = 2)] LivingTogetherUnmarried = 1,
    [Display(Description = "Married", Order = 3)] Married = 2,
    [Display(Description = "Separated", Order = 4)] Separated = 3,
    [Display(Description = "Divorced", Order = 5)] Divorced = 4,
    [Display(Description = "Widowed", Order = 6)] Widowed = 5,
}
