using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum LastGradeEnum : short
{
    [Display(Description = "Didn't complete schooling", Order = 1)] DidntCompleteSchooling = 0,
    [Display(Description = "GED", Order = 2)] GED = 1,
    [Display(Description = "High school diploma", Order = 3)] HighSchoolDiploma = 2,
    [Display(Description = "Some college", Order = 4)] SomeCollege = 3,
    [Display(Description = "Associate degree", Order = 5)] AssociateDegree = 4,
    [Display(Description = "Bachelor degree", Order = 6)] BachelorDegree = 5,
    [Display(Description = "Master degree or higher", Order = 7)] MasterDegreeOrHigher = 6,
}
