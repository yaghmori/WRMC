using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;


public enum OccupationRequiredEnum : short
{
    EmployedFullTime = EmploymentEnum.EmployedFullTime,
    EmployedPartTime = EmploymentEnum.EmployedPartTime,
    SelfEmployed = EmploymentEnum.SelfEmployed,
}
public enum EmployerRequiredEnum : short
{
    EmployedFullTime = EmploymentEnum.EmployedFullTime,
    EmployedPartTime = EmploymentEnum.EmployedPartTime,
}

public enum EmploymentEnum : short
{
    [Display(Description = "Employed Full-time", Order = 1)]
    EmployedFullTime = 0,
    [Display(Description = "Employed Part-time (20 hours or less per week)", Order = 2)]
    EmployedPartTime = 1,
    [Display(Description = "Self Employed", Order = 3)]
    SelfEmployed = 2,
    [Display(Description = "Unemployed – Looking", Order = 4)]
    UnemployedLooking = 3,
    [Display(Description = "Unemployed – Not looking", Order = 5)]
    UnemployedNotlooking = 4,
    [Display(Description = "Student", Order = 6)]
    Student = 5,
    [Display(Description = "Homemaker", Order = 7)]
    Homemaker = 6,
}
