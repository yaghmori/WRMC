using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum DiscussionTopicsEnum : short
{
    [Display(Description = "Abortion (Procedures & Risks)", Order = 13)] Abortion = 0,
    [Display(Description = "Abstinence (Sexual Integrity / Relationships / Pre-Marital)", Order = 24)] Abstinence = 1,
    [Display(Description = "Birth Control Risks", Order = 20)] BirthControlRisks = 2,
    [Display(Description = "Abuse (Physical / Emotional / Spiritual / Sexual / Trafficking)", Order = 4)] Abuse = 3,
    [Display(Description = "Pregnancy (Fetal Development)", Order = 6)] Pregnancy = 4,
    [Display(Description = "Prenatal Care (Nutrition / Education/Vitamins)", Order = 7)] PrenatalCare = 5,
    [Display(Description = "Adoption / Birth Families", Order = 18)] AdoptionBirthFamilies = 6,
    [Display(Description = "Parenting (Single & Co-Parenting)", Order = 8)] Parenting = 7,
    [Display(Description = "Childbirth / Newborns / Breastfeeding", Order = 9)] ChildbirthNewbornsBreastfeeding = 8,
    [Display(Description = "Emotional & Spiritual Support", Order = 10)] Emotional = 9,
    [Display(Description = "Gospel", Order = 11)] Gospel = 10,
    [Display(Description = "Men's Role / Rights / Fatherhood", Order = 12)] MensRole = 11,
    [Display(Description = "Pregnancy Grief & Loss (Miscarriage / Stillborn)", Order = 1)] PregnancyGrief = 12,
    [Display(Description = "Adverse Pregnancy Diagnoses", Order = 14)] AdversePregnancyDiagnoses = 13,
    [Display(Description = "STD/STI Risks", Order = 15)] StdStiRisks = 14,
    [Display(Description = "Post Abortion (Women)", Order = 16)] WomenPostAbortion = 15,
    [Display(Description = "Post Abortion (Men)", Order = 17)] MenPostAbortion = 16,
    [Display(Description = "Educational Classes", Order = 5)] EducationalClasses = 17,
    [Display(Description = "Decision Making Skills", Order = 19)] DecisionMakingSkills = 18,
    [Display(Description = "Ultrasound Information", Order = 3)] UltrasoundInformation = 19,
    [Display(Description = "Bible", Order = 21)] Bible = 20,
    [Display(Description = "Marriage / Family / Blended Families", Order = 22)] MarriageFamilyBlendedFamilies = 21,
    [Display(Description = "Addiction", Order = 23)] Addiction = 22,
    [Display(Description = "Hydration", Order = 2)] Hydration = 24,
    [Display(Description = "Ectopic Pregnancy", Order = 25)] EctopicPregnancy = 25,
    [Display(Description = "Other", Order = 1000)] Other = 1000,
}
