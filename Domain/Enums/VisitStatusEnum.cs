using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum VisitStatusEnum : short
{
    [Display(Description ="All sections complete successfully")]
    Completed = 0,
    [Display(Description = "Sections are in progress")]
    InProgress = 1,
    [Display(Description = "Canceled by client")]
    Canceled = 2,
    [Display(Description = "Rejected by center")]
    Rejected = 3,
}
