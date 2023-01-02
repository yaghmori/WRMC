using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum SocialIntentionEnum : short
{
    [Display(Description = "Abort", Order = 4)] Abort = 0,
    [Display(Description = "Keep", Order = 2)] Keep = 1,
    [Display(Description = "Adopt", Order = 3)] Adopt = 2,
    [Display(Description = "No Support", Order = 1)] NoSupport = 3,
    [Display(Description = "Not Sure", Order = 5)] NotSure = 4,
}
