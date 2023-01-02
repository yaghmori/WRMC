using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum ExtraPhoneTypeEnum : short
{
    [Display(Description = "Home", Order = 1)] Home = 0,
    [Display(Description = "Work", Order = 2)] Work = 1,
    [Display(Description = "Cell", Order = 3)] Cell = 2,
}
