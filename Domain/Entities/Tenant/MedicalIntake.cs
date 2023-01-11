using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class MedicalIntake : BaseEntity<Guid>
    {
        public Guid? VisitId { get; set; }
        public Guid? TaskId { get; set; }
        public bool IsComplete { get; set; } = false;

        public bool? IsPeriodRemember { get; set; }
        public DateTime? LastPeriodDate { get; set; }
        public bool? HaveNormalPeriod { get; set; }
        public string? NormalPeriodNote { get; set; }
        public short? FirstMenstrualAge { get; set; }
        public DateTime? LastSexIntercourse { get; set; }
        public string Symptoms { get; set; }
        public string? OtherSymptoms { get; set; }
        public bool? MedicalConditions { get; set; }
        public string? MedicalConditionsNote { get; set; }
        public bool? DoctorCare { get; set; }
        public bool? Medication { get; set; } 
        public string? MedicationType { get; set; } 
        public bool? BlackboxMedication { get; set; } 
        public bool? HavePapSmear { get; set; }
        public DateTime? LastExaminationDate { get; set; } 
        public bool? UseAlcohol { get; set; }
        public DateTime? AlcoholQuitDate { get; set; }
        public AlcoholFreqEnum? AlcoholFrequency { get; set; }
        public AlcoholFreqEnum? AlcoholPriorFreq { get; set; } 
        public short? AlcoholTotalYears { get; set; } 
        public bool? UseTobacco { get; set; }
        public DateTime? TobaccoQuitDate { get; set; } 
        public TobaccoFreqEnum? TobaccoFrequency { get; set; } 
        public TobaccoFreqEnum? TobaccoPriorFreq { get; set; }
        public short? TobaccoTotalYears { get; set; } 
        public bool? UseDrugs { get; set; }
        public DateTime? DrugsQuitDate { get; set; } 
        public string? DrugFrequency { get; set; }
        public short? DrugsTotalYears { get; set; } 
        public short? BirthsQty { get; set; } 
        public short? MiscarriageQty { get; set; } 
        public short? AbortionQty { get; set; } 
        public AbortionTypeEnum? AbortionType { get; set; }
        public DateTime? AbortionDate { get; set; } 
        public bool? AbortionIssues { get; set; }
        public bool? HavePlanB { get; set; }
        public short? PlanBQty { get; set; } 
        public DateTime? LastPlanBDate { get; set; }
        public bool? HaveBirthControl { get; set; }
        public DateTime? BirthControlEnd { get; set; } 
        public BirthControlEnum? BirthControlType { get; set; } 
        public string? OtherBirthControlType { get; set; }
        public BirthControlLongEnum? BirthControlLong { get; set; } 
        public short? SexualActive { get; set; } 
        public short? SexualPartners { get; set; } 
        public bool? HaveStdTest { get; set; }
        public string StdTypes { get; set; } 
        public DateTime? StdTestDate { get; set; } 
        public bool? StdTestResult { get; set; }
        public bool? HaveTreatment { get; set; } 
        public bool? PartnerNotified { get; set; }
        public bool? AdversePrenatal { get; set; } 
        public bool? HaveRapeAbuse { get; set; }
        public string? RapeAbuseNotes { get; set; }
        public virtual IntentionsEnum? Intentions { get; set; } 
        public bool? AdoptionOption { get; set; }
        public AbortionRiskEnum? AbortionRisk { get; set; }

        public virtual Visit? Visit { get; set; }
        public virtual Tasks? Task { get; set; }

    }
}
