using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum SymptomsEnum : short
{
    [Display(Description = "No Symptoms", Order = 0)] NoSymptoms = 0,
    [Display(Description = "Nausea and/or Vomiting", Order = 1)] NauseaandVomiting = 1,
    [Display(Description = "Frequent Urination", Order = 2)] FrequentUrination = 2,
    [Display(Description = "Swollen and/or Sore Breasts", Order = 3)] SwollenandSoreBreasts = 3,
    [Display(Description = "Light Headed and/or Dizziness", Order = 4)] LightHeadedDizziness = 4,
    [Display(Description = "Appetite Change", Order = 5)] AppetiteChange = 5,
    [Display(Description = "Weight Gain or Weight Loss", Order = 6)] WeightGainLoss = 6,
    [Display(Description = "Tiredness", Order = 7)] Tiredness = 7,
    [Display(Description = "Cramps", Order = 8)] Cramps = 8,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
