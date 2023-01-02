using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum LiteratureCategoriesEnum : short
{
    [Display(Description = "Abortion (Procedures & Risks)", Order = 1)] Abortion = 0,
    [Display(Description = "Abstinence (Sexual Integrity / Relationships / Pre-Marital)", Order = 2)] Abstinence = 1,
    [Display(Description = "Birth Control Risks", Order = 9)] BirthControlRisks = 2,
    [Display(Description = "Abuse (Physical / Emotional / Spiritual / Sexual / Trafficking)", Order = 3)] Abuse = 3,
    [Display(Description = "Pregnancy (Fetal Development)", Order = 23)] Pregnancy = 4,
    [Display(Description = "Prenatal Care (Nutrition / Education)", Order = 25)] PrenatalCare = 5,
    [Display(Description = "Adoption / Birth Families", Order = 5)] AdoptionBirthFamilies = 6,
    [Display(Description = "Parenting (Single & Co-Parenting)", Order = 20)] Parenting = 7,
    [Display(Description = "Childbirth / Newborns / Breastfeeding", Order = 10)] ChildbirthNewbornsBreastfeeding = 8,
    [Display(Description = "Emotional & Spiritual Support", Order = 14)] EmotionalSpiritualSupport = 9,
    [Display(Description = "Gospel", Order = 16)] Gospel = 10,
    [Display(Description = "Men's Role / Rights / Fatherhood", Order = 18)] MensRole = 11,
    [Display(Description = "Pregnancy Grief & Loss (Miscarriage / Stillborn)", Order = 24)] PregnancyGriefAndLoss = 12,
    [Display(Description = "Adverse Pregnancy Diagnoses", Order = 6)] AdversePregnancyDiagnoses = 13,
    [Display(Description = "STD/STI Risks", Order = 26)] STDSTIRisks = 14,
    [Display(Description = "Post Abortion (Women)", Order = 22)] WomenPostAbortion = 15,
    [Display(Description = "Post Abortion (Men)", Order = 21)] MenPostAbortion = 16,
    [Display(Description = "Educational Classes", Order = 13)] EducationalClasses = 17,
    [Display(Description = "Decision Making Skills", Order = 11)] DecisionMakingSkills = 18,
    [Display(Description = "Ultrasound Information", Order = 27)] UltrasoundInformation = 19,
    [Display(Description = "Bible", Order = 8)] Bible = 20,
    [Display(Description = "Marriage / Family / Blended Families", Order = 17)] MarriageFamilyBlendedFamilies = 21,
    [Display(Description = "Addiction", Order = 4)] Addiction = 22,
    [Display(Description = "Discipleship Booklet", Order = 12)] DiscipleshipBooklet = 23,
    [Display(Description = "Evangelism Tracts", Order = 15)] EvangelismTracts = 24,
    [Display(Description = "Verification of Positive Letter", Order = 28)] VerificationofPositiveLetter = 25,
    [Display(Description = "Negative Test Information", Order = 19)] NegativeTestInformation = 26,
    [Display(Description = "Other", Order = 29)] Other = 1000,
    [Display(Description = "Baby Booties", Order = 7)] BabyBooties = 28,
}
