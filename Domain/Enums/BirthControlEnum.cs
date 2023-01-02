using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum BirthControlEnum : short
{
    [Display(Description = "Birth Control Pill", Order = 1)] BirthControlPill = 0,
    [Display(Description = "Condoms", Order = 2)] Condoms = 1,
    [Display(Description = "IUD", Order = 3)] IUD = 2,
    [Display(Description = "Patch", Order = 4)] Patch = 3,
    [Display(Description = "Depo Shot", Order = 5)] DepoShot = 4,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
