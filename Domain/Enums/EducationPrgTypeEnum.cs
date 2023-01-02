using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum EducationPrgTypeEnum : short
{
    [Display(Description = "Bright Course Lists", Order = 1)] BrightCourseLists = 0,
    [Display(Description = "Online Class Assignment", Order = 2)] OnlineClassAssignment = 1,
    [Display(Description = "Group Class Assignment", Order = 3)] GroupClassAssignment = 2,
    [Display(Description = "One on One Class Assignment", Order = 4)] OneOnOneClassAssignment = 3,
}
