using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum DiagnosisEnum : short
{
    [Display(Description = "Diabetes", Order = 1)] Diabetes = 0,
    [Display(Description = "Hypertension", Order = 2)] Hypertension = 1,
    [Display(Description = "Heart Disease", Order = 3)] HeartDisease = 2,
    [Display(Description = "Autoimmune Disorder", Order = 4)] AutoimmuneDisorder = 3,
    [Display(Description = "Kidney Disease/UTI", Order = 5)] KidneyDiseaseUTI = 4,
    [Display(Description = "Psychiatric", Order = 6)] Psychiatric = 5,
    [Display(Description = "Neurological/Epilepsy", Order = 7)] NeurologicalEpilepsy = 6,
    [Display(Description = "Hepatitis/Liver Disease", Order = 8)] HepatitisLiverDisease = 7,
    [Display(Description = "Varicosities/Phlebitis", Order = 9)] VaricositiesPhlebitis = 8,
    [Display(Description = "Thyroid Dysfunction", Order = 10)] ThyroidDysfunction = 9,
    [Display(Description = "Trauma/Domestic Violence", Order = 11)] TraumaDomesticViolence = 10,
    [Display(Description = "History of Blood Transfusion", Order = 12)] HistoryofBloodTransfusion = 11,
    [Display(Description = "D (RH) Sensitized", Order = 13)] DSensitized = 12,
    [Display(Description = "Pulmonary (TB or Asthma)", Order = 14)] Pulmonary = 13,
    [Display(Description = "Uterine Anomaly/DES", Order = 15)] UterineAnomalyDES = 14,
    [Display(Description = "Relevant Family History", Order = 16)] RelevantFamilyHistory = 15,
    [Display(Description = "Gyn Surgery", Order = 17)] GynSurgery = 16,
}
