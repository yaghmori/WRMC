using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class MedicalIntake : BaseEntity<Guid>
    {
        public Guid? VisitId { get; set; }
        public Guid? TaskId { get; set; }
        public bool? IsPeriodRemember { get; set; } // Yes No
        public DateTime? LastPeriodDate { get; set; } // Date Picker
        public bool? HaveNormalPeriod { get; set; } // Yes No
        public string? NormalPeriodNote { get; set; } // Simple Input box
        public short? FirstMenstrualAge { get; set; } // Numeric Input box
        public DateTime? LastSexIntercourse { get; set; } // Date Picker (Year/Month only)
        public string Symptoms { get; set; } // Multi Select - List is populated from Symptoms enumname of enums table
        public string? OtherSymptoms { get; set; } // Simple Input box (Visible if Symptoms other option is selected)
        public bool? MedicalConditions { get; set; } // Yes No
        public string? MedicalConditionsNote { get; set; } // Simple Input box (Visible if MedicalConditions is Yes)
        public bool? DoctorCare { get; set; } // Yes No
        public bool? Medication { get; set; } // Yes No
        public string? MedicationType { get; set; } // Simple Input box (Visible if Medication is Yes)
        public bool? BlackboxMedication { get; set; } // Yes No
        public bool? HavePapSmear { get; set; } // Yes No
        public DateTime? LastExaminationDate { get; set; } // Date Picker (Year/Month only)
        public bool? UseAlcohol { get; set; } // Yes No
        public DateTime? AlcoholQuitDate { get; set; } // Date Picker (Year/Month only)
        public AlcoholFreqEnum? AlcoholFrequency { get; set; } // Single Select - List is populated from AlcoholFreq enumname of enums table
        public AlcoholFreqEnum? AlcoholPriorFreq { get; set; } // Single Select - List is populated from AlcoholFreq enumname of enums table
        public short? AlcoholTotalYears { get; set; } // Numeric Input box
        public bool? UseTobacco { get; set; } // Yes No
        public DateTime? TobaccoQuitDate { get; set; } // Date Picker (Year/Month only)
        public TobaccoFreqEnum? TobaccoFrequency { get; set; } // Single Select - List is populated from TobaccoFreq enumname of enums table
        public TobaccoFreqEnum? TobaccoPriorFreq { get; set; } // Single Select - List is populated from TobaccoFreq enumname of enums table
        public short? TobaccoTotalYears { get; set; } // Numeric Input box
        public bool? UseDrugs { get; set; } // Yes No
        public DateTime? DrugsQuitDate { get; set; } // Date Picker (Year/Month only)
        public string? DrugFrequency { get; set; } //Json List<DrugTypeResponse>
        public short? DrugsTotalYears { get; set; } // Numeric Input box
        public short? BirthsQty { get; set; } // Numeric Input box (Required, 0 if no children at all)
        public short? MiscarriageQty { get; set; } // Numeric Input box (Not required)
        public short? AbortionQty { get; set; } // Numeric Input box (Not required)
        public AbortionTypeEnum? AbortionType { get; set; } // Chemical or Surgical (Visible if AbortionQty is not null and is greater than 0)
        public DateTime? AbortionDate { get; set; } // Date Picker (Year/Month only - Visible if AbortionQty is not null and is greater than 0)
        public bool? AbortionIssues { get; set; } // Yes No 
        public bool? HavePlanB { get; set; } // Yes No
        public short? PlanBQty { get; set; } // Numeric Input box (Visible if HavePlanB is Yes)
        public DateTime? LastPlanBDate { get; set; } // Date Picker (Year/Month only - Visible if HavePlanB is Yes)
        public bool? HaveBirthControl { get; set; } // Yes No
        public DateTime? BirthControlEnd { get; set; } // Date Picker (Year/Month only)
        public BirthControlEnum? BirthControlType { get; set; }  // Single Select - List is populated from BirthControl enumname of enums table
        public string? OtherBirthControlType { get; set; } // Simple Input box (Visible if BirthControlType other option is selected)
        public BirthControlLongEnum? BirthControlLong { get; set; }  // Single Select - List is populated from BirthControlLong enumname of enums table
        public short? SexualActive { get; set; } // Numeric Input box 
        public short? SexualPartners { get; set; } // Numeric Input box 
        public bool? HaveStdTest { get; set; } // Yes No
        public string StdTypes { get; set; } // Multi Select - List is populated from STDTypes enumname of enums table
        public DateTime? StdTestDate { get; set; } // Date Picker (Year/Month only - Visible if HaveStdTest is Yes)
        public bool? StdTestResult { get; set; } // Positive or Negative - Visible if HaveStdTest is Yes
        public bool? HaveTreatment { get; set; } // Yes No - Visible if StdTestResult is positive
        public bool? PartnerNotified { get; set; } // Yes No - Visible if StdTestResult is positive
        public bool? AdversePrenatal { get; set; } // Yes No
        public bool? HaveRapeAbuse { get; set; } // Yes No
        public string? RapeAbuseNotes { get; set; } // Simple Input box (Visible if HaveRapeAbuse is Yes)
        public virtual IntentionsEnum? Intentions { get; set; } // Single Select - List is populated from Intentions enumname of enums table
        public bool? AdoptionOption { get; set; } // Yes No
        public AbortionRiskEnum? AbortionRisk { get; set; }
        public bool IsComplete { get; set; }= false;

        public virtual Visit? Visit { get; set; }
        public virtual Tasks? Task { get; set; }

    }
}
