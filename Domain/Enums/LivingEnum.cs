using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum LivingEnum : short
{
    [Display(Description = "Alone", Order = 1)] Alone = 0,
    [Display(Description = "Spouse", Order = 2)] Spouse = 1,
    [Display(Description = "Parent(s)", Order = 3)] Parent = 2,
    [Display(Description = "Boyfriend/Fiancé", Order = 4)] BoyfriendFiance = 3,
    [Display(Description = "Friends/Relatives", Order = 5)] FriendsRelatives = 4,
    [Display(Description = "Weekly Rentals", Order = 6)] WeeklyRentals = 5,
    [Display(Description = "Homeless", Order = 7)] Homeless = 6,
}
