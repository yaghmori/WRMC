using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum MultipleBirthsEnum : short
{
    [Display(Description = "Single", Order = 1)]Single = 0,
    [Display(Description = "Twins", Order = 2)] Twins = 1,
    [Display(Description = "Triplets", Order = 3)] Triplets = 2,
    [Display(Description = "Quadruplets", Order = 4)] Quadruplets = 3,
    [Display(Description = "Quintuplets", Order = 5)] Quintuplets = 4,
    [Display(Description = "Sextuplets", Order = 6)] Sextuplets = 5,
    [Display(Description = "Above Sextuplets", Order = 7)] AboveSextuplets = 6,
}
