using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum GeneticsScreeningEnum : short
{
    [Display(Description = "Patients age is greater than 35 years", Order = 1)] PatientsAge = 0,
    [Display(Description = "Thalassemia (Italian, Greek, Mediterranean or Asian Background - Mcv Is Less Than 60)", Order = 2)] Thalassemia = 1,
    [Display(Description = "Neural Tube Defect (Meningomyelocele, Spina Bifida or Anencephaly)", Order = 3)] NeuralTubeDefect = 2,
    [Display(Description = "Congenital Heart Defect", Order = 4)] CongenitalHeartDefect = 3,
    [Display(Description = "Down Syndrome", Order = 5)] DownSyndrome = 4,
    [Display(Description = "Tay-Sachs (e.g. Jewish, Cajun, French or Canadian)", Order = 6)] TaySachs = 5,
    [Display(Description = "Sickle Cell Disease or Trait (African)", Order = 7)] African = 6,
    [Display(Description = "Hemophilia", Order = 8)] Hemophilia = 7,
    [Display(Description = "Muscular Dystrophy", Order = 9)] MuscularDystrophy = 8,
    [Display(Description = "Cystic Fibrosis", Order = 10)] CysticFibrosis = 9,
    [Display(Description = "Huntington Chorea", Order = 11)] HuntingtonChorea = 10,
    [Display(Description = "Recurrent pregnancy loss or a stillbirth", Order = 12)] RecurrentPregnancyLoss = 11,
    [Display(Description = "Mental retardation / autism", Order = 13)] MentalRetardationAutism = 12,
    [Display(Description = "If having mental retardation / autism is positive, was person tested for Fragile X", Order = 14)] TestedforFragileX = 13,
    [Display(Description = "Other inherited genetic or chromosomal disorder", Order = 15)] OtherInheritedGeneticDisorder = 14,
    [Display(Description = "Material Metabolic Disorder (e.g. Insulin-Dependent Diabetes, PKU)", Order = 16)] MaterialMetabolicDisorder = 15,
    [Display(Description = "Patient or baby's father had a child with birth defects", Order = 17)] HadChildWithBirthDefects = 16,
    [Display(Description = "Medications / Street drugs / Alcohol since last menstrual period", Order = 18)] MedicationsStreetDrugsAlcohol = 17,
}
