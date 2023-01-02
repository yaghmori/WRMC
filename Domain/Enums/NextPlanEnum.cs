using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum NextPlanEnum : short
{
    [Display(Description = "Get an ultrasound", Order = 1)] Getanultrasound = 0,
    [Display(Description = "See my OB Doctor", Order = 2)] SeemyOBDoctor = 1,
    [Display(Description = "Find a Doctor", Order = 3)] FindaDoctor = 2,
    [Display(Description = "Get prenatal care", Order = 4)] Getprenatalcare = 3,
    [Display(Description = "Retest appointment", Order = 5)] Retestappointment = 4,
    [Display(Description = "Apply for Standard Medicaid", Order = 6)] ApplyforStandardMedicaid = 5,
    [Display(Description = "Apply for Emergency Medical", Order = 7)] ApplyforEmergencyMedical = 6,
    [Display(Description = "To get private insurance", Order = 8)] Togetprivateinsurance = 7,
    [Display(Description = "Talk to my partner", Order = 9)] Talktomypartner = 8,
    [Display(Description = "Talk to my parents", Order = 10)] Talktomyparents = 9,
    [Display(Description = "Apply for a job", Order = 11)] Applyforajob = 10,
    [Display(Description = "Finish school", Order = 12)] Finishschool = 11,
    [Display(Description = "Find a place to stay", Order = 13)] Findaplacetostay = 12,
    [Display(Description = "Still considering abortion", Order = 14)] Stillconsideringabortion = 13,
    [Display(Description = "Considering adoption", Order = 15)] Consideringadoption = 14,
    [Display(Description = "Ultrasound for gender", Order = 16)] Ultrasoundforgender = 15,
    [Display(Description = "Save money", Order = 17)] Savemoney = 16,
    [Display(Description = "Apply for welfare assistance", Order = 18)] Applyforwelfareassistance = 17,
    [Display(Description = "Immigration Assistance", Order = 19)] ImmigrationAssistance = 18,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
