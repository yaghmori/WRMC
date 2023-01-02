using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum DrugFreqEnum : short
{
    [Display(Description = "Daily", Order = 1)] Daily = 0,
    [Display(Description = "Weekly", Order = 2)] Weekly = 1,
    [Display(Description = "Monthly", Order = 3)] Monthly = 2,
}
