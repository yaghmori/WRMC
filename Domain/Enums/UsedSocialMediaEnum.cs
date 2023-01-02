using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum UsedSocialMediaEnum : short
{
    [Display(Description = "Facebook", Order = 1)] Facebook = 0,
    [Display(Description = "SnapChat", Order = 2)] SnapChat = 1,
    [Display(Description = "Instagram", Order = 3)] Instagram = 2,
    [Display(Description = "Yelp", Order = 4)] Yelp = 3,
    [Display(Description = "Google+", Order = 5)] GooglePlus = 4,
    [Display(Description = "Twitter", Order = 6)] Twitter = 5,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
