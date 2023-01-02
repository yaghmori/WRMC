using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum StatedIntentionEnum : short
{
    [Display(Description = "NA", Order = 6)] Na = 0,
    [Display(Description = "Unsure", Order = 1)] Unsure = 1,
    [Display(Description = "Carry/Parent", Order = 2)] CarryParent = 2,
    [Display(Description = "Carry/Adoption", Order = 3)] CarryAdoption = 3,
    [Display(Description = "Carry/Undecided", Order = 4)] CarryUndecided = 4,
    [Display(Description = "Abortion", Order = 5)] Abortion = 2,
}
