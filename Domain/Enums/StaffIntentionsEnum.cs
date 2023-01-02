using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum StaffIntentionsEnum : short
{
    [Display(Description = "C/P", Order = 1)] Cp = 1,
    [Display(Description = "ABV", Order = 3)] Abv = 2,
    [Display(Description = "ABM", Order = 2)] Abm = 3,
    [Display(Description = "UND", Order = 4)] Und = 4,
    [Display(Description = "Adopt.", Order = 5)] Adopt = 5,
}
