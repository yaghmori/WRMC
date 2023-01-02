using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum SocialMediaEnum : short
{
    [Display(Description = "Google Ads", Order = 1)] GoogleAds = 1,
    [Display(Description = "Facebook", Order = 2)] Facebook = 2,
    [Display(Description = "Yelp", Order = 3)] Yelp = 3,
    [Display(Description = "Instagram", Order = 4)] Instagram = 4,
    [Display(Description = "Twitter", Order = 5)] Twitter = 5,
    [Display(Description = "Game Apps", Order = 6)] GameApps = 6,
    [Display(Description = "Tinder", Order = 7)] Tinder = 7,
    [Display(Description = "Signage", Order = 8)] Signage = 8,
    [Display(Description = "Medical Mobile Unit Sign", Order = 9)] MedicalMobileUnitSign = 9,
}
