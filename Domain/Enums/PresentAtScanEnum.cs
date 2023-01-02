using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum PresentAtScanEnum : short
{
    [Display(Description = "Husband", Order = 1)] Husband = 1,
    [Display(Description = "Boy Friend", Order = 2)] BoyFriend = 2,
    [Display(Description = "Parent", Order = 3)] Parent = 3,
    [Display(Description = "Sibling", Order = 4)] Sibling = 4,
    [Display(Description = "Child / Children", Order = 5)] Children = 5,
    [Display(Description = "Friend", Order = 6)] Friend = 6,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
