using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum RaceEnum : short
{
    [Display(Description = "Caucasian or White", Order = 1)] CaucasianWhite = 0,
    [Display(Description = "American Indian/Alaska Native", Order = 2)] AmericanIndianAlaskaNative = 1,
    [Display(Description = "Asian", Order = 3)] Asian = 2,
    [Display(Description = "African American or Black", Order = 4)] AfricanAmericanBlack = 3,
    [Display(Description = "Hispanic or Latino", Order = 5)] HispanicLatino = 4,
    [Display(Description = "Hawaiian or Pacific Islander", Order = 6)] HawaiianPacificIslander = 5,
    [Display(Description = "Middle Eastern", Order = 7)] MiddleEastern = 6,
    [Display(Description = "Multi Racial", Order = 8)] MultiRacial = 7,
}
