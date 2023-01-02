using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum InformedEnum : short
{
    [Display(Description = "Fetal Development", Order = 1)] FetalDevelopment = 1,
    [Display(Description = "Nutrition", Order = 2)] Nutrition = 2,
    [Display(Description = "Hydration", Order = 3)] Hydration = 3,
    [Display(Description = "Abortion Procedures / Risks", Order = 4)] AbortionProceduresRisks = 4,
    [Display(Description = "Miscarriage / Ectopic Pregnancy", Order = 5)] MiscarriageEctopicPregnancy = 5,
    [Display(Description = "Prenatal Vitamins", Order = 6)] PrenatalVitamins = 6,
    [Display(Description = "Values Pregnancy Program", Order = 7)] ValuesPregnancyProgram = 7,
    [Display(Description = "Healthy Relationship", Order = 8)] HealthyRelationship = 8,
    [Display(Description = "Safety (Self / Pregnancy)", Order = 9)] Safety = 9,
    [Display(Description = "Adoption", Order = 10)] Adoption = 10,
    [Display(Description = "Abstinence / STDs", Order = 11)] AbstinenceStd = 11,
}
