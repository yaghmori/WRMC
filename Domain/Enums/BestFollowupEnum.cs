using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum BestFollowupEnum : short
{
    [Display(Description = "Email", Order = 1)] Email = 0,
    [Display(Description = "Phone Call", Order = 2)] PhoneCall = 1,
    [Display(Description = "Text", Order = 3)] Text = 2,
}
