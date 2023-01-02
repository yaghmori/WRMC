using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum DrugAllergyTypeEnum : short
{
    [Display(Description = "Skin rash or reddened skin", Order = 1)] SkinRash = 0,
    [Display(Description = "Itching", Order = 2)] Itching = 1,
    [Display(Description = "Wheezing", Order = 3)] Wheezing = 2,
    [Display(Description = "Swelling", Order = 4)] Swelling = 3,
    [Display(Description = "Throat tightness", Order = 5)] ThroatTightness = 4,
    [Display(Description = "Light-headed", Order = 6)] LightHeaded = 5,
    [Display(Description = "Hives or blisters", Order = 7)] HivesOrBlisters = 6,
    [Display(Description = "Low blood pressure", Order = 8)] LowBloodPressure = 7,
    [Display(Description = "High blood pressure", Order = 9)] HighBloodPressure = 8,
    [Display(Description = "Other breathing problems", Order = 10)] OtherBreathingProblems = 9,
    [Display(Description = "Other skin problems", Order = 11)] OtherSkinProblems = 10,
    [Display(Description = "Whole-body shock", Order = 12)] WholeBodyShock = 11,
}
