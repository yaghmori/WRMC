using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum PreferShareEnum : short
{
    [Display(Description = "FOB", Order = 1)] Fob = 0,
    [Display(Description = "Parent(s)", Order = 2)] Parent = 1,
    [Display(Description = "Friend", Order = 3)] Friend = 2,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
