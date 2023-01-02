using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum AbortionClinicEnum : short
{
    [Display(Description = "Planned Parenthood", Order = 1)] PlannedParenthood = 0,
    [Display(Description = "Birth Control Center", Order = 2)] BirthControlCenter = 1,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
