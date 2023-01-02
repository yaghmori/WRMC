using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum RateEnum : short
{
    [Display(Description = "1 Lowest", Order = 1)] Lowest = 1,
    [Display(Description = "2", Order = 2)] Two = 2,
    [Display(Description = "3", Order = 3)] Three = 3,
    [Display(Description = "4", Order = 4)] Four = 4,
    [Display(Description = "5 Highest", Order = 5)] Highest = 5,
}
