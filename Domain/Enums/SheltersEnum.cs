using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum SheltersEnum : short
{
    [Display(Description = "Las Vegas Rescue Mission", Order = 1)] LasVegasRescueMission = 0,
    [Display(Description = "Shade Tree", Order = 2)] ShadeTree = 1,
    [Display(Description = "SafeNest", Order = 3)] SafeNest = 2,
    [Display(Description = "Nevada Youth Partnership", Order = 4)] NevadaYouthPartnership = 3,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
