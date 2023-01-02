using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum MedicalReferralsEnum : short
{
    [Display(Description = "Dr. Sauter", Order = 1)] DrSauter = 0,
    [Display(Description = "Dr. Herrero", Order = 2)] DrHerrero = 1,
    [Display(Description = "Dr. Strebel", Order = 3)] DrStrebel = 2,
    [Display(Description = "UNLV Medicine", Order = 4)] UNLVMedicine = 3,
    [Display(Description = "Baby Steps UMC", Order = 5)] BabyStepsUMC = 4,
    [Display(Description = "Sunny Babies", Order = 6)] SunnyBabies = 5,
    [Display(Description = "Mountain View Hospital", Order = 7)] MountainViewHospital = 6,
    [Display(Description = "Health Department", Order = 8)] HealthDepartment = 7,
}
