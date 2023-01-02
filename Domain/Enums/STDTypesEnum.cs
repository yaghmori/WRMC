using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum STDTypesEnum : short
{
    [Display(Description = "Gonorrhea", Order = 1)] Gonorrhea = 1,
    [Display(Description = "Chlamydia", Order = 2)] Chlamydia = 2,
    [Display(Description = "Herpes", Order = 3)] Herpes = 3,
    [Display(Description = "Hepatitis B", Order = 4)] HepatitisB = 4,
    [Display(Description = "HIV", Order = 5)] HIV = 5,
    [Display(Description = "Syphilis", Order = 6)] Syphilis = 6,
    [Display(Description = "Genital Warts", Order = 7)] GenitalWarts = 7,
    [Display(Description = "Pelvic Inflammatory Disease", Order = 8)] PelvicInflammatoryDisease = 8,
    [Display(Description = "Trichomonas", Order = 9)] Trichomonas = 9,
    [Display(Description = "HPV", Order = 10)] Hpv = 10,
}
