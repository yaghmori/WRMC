using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum ChangeReasonsEnum : short
{
    [Display(Description = "Client changed his/her mind at window", Order = 1)] ClientChangedMindAtWindow = 0,
    [Display(Description = "Client needs to check schedule and call back", Order = 2)] ClientCheckScheduleAndCallback = 1,
    [Display(Description = "Change requested by Checkout Coordinator/Manager", Order = 3)] RequestedByCcManager = 2,
}
