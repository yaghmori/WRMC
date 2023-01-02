using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum DeliveryTypesEnum : short
{
    [Display(Description = "Vaginal Birth", Order = 1)] VaginalBirth = 0,
    [Display(Description = "Natural Birth", Order = 2)] NaturalBirth = 1,
    [Display(Description = "Scheduled Cesarean", Order = 3)] ScheduledCesarean = 2,
    [Display(Description = "Unplanned Cesarean", Order = 4)] UnplannedCesarean = 3,
    [Display(Description = "Vaginal Birth after C-Section", Order = 5)] VaginalBirthAfterCSection = 4,
    [Display(Description = "Scheduled Induction", Order = 6)] ScheduledInduction = 5,
}
