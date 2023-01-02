using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum IntentionsEnum : short
{
    [Display(Description = "Unsure", Order = 1)] Unsure = 0,
    [Display(Description = "Carry/Parent", Order = 2)] CarryParent = 1,
    [Display(Description = "Carry/Adoption", Order = 3)] CarryAdoption = 2,
    [Display(Description = "Carry/Undecided", Order = 4)] CarryUndecided = 3,
    [Display(Description = "Abortion", Order = 5)] Abortion = 4,
}
