using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum BirthControlLongEnum : short
{
    [Display(Description = "Less than a year", Order = 1)] LessThanYear = 0,
    [Display(Description = "1 to 2 years", Order = 2)] OneToTwoYears = 1,
    [Display(Description = "More than 2 years", Order = 3)] MoreThanTwoYears = 2,
}
