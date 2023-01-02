using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ValidationAttributes;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests
{
    public class MedicalIntakeRequest
    {
        public string? VisitId { get; set; }
        public string? TaskId { get; set; }

        [Required]
        public bool? IsPeriodRemember { get; set; }

        public DateTime? LastPeriodDate { get; set; }
        public bool? HaveNormalPeriod { get; set; }

        [RequiredIf(nameof(HaveNormalPeriod), false)]
        public string? NormalPeriodNote { get; set; }

        [Required]
        public short? FirstMenstrualAge { get; set; }

        [Required]
        public DateTime? LastSexIntercourse { get; set; } 


        public List<SymptomsEnum> Symptoms { get; set; }

        [MaxLength(512, ErrorMessage = "Maximum {1} characters")]
        public string? OtherSymptoms { get; set; }

        [Required]
        public bool? MedicalConditions { get; set; }

        [MaxLength(512, ErrorMessage = "Maximum {1} characters")]
        [RequiredIf(nameof(MedicalConditions), true)]
        public string? MedicalConditionsNote { get; set; }

        [Required]
        public bool? DoctorCare { get; set; }

        [Required]
        public bool? Medication { get; set; }

        [MaxLength(512, ErrorMessage = "Maximum {1} characters")]
        [RequiredIf(nameof(Medication), true)]
        public string? MedicationType { get; set; }

        [Required]
        public bool? BlackboxMedication { get; set; }

        [Required]
        public bool? HavePapSmear { get; set; }

        [RequiredIf(nameof(HavePapSmear), true)]
        public DateTime? LastExaminationDate { get; set; }

        [Required]
        public bool? UseAlcohol { get; set; }

        public DateTime? AlcoholQuitDate { get; set; }

        [RequiredIf(nameof(UseAlcohol), true)]
        public AlcoholFreqEnum? AlcoholFrequency { get; set; }

        [RequiredIf(nameof(UseAlcohol), true)]
        public AlcoholFreqEnum? AlcoholPriorFreq { get; set; }

        [RequiredIf(nameof(UseAlcohol), true)]
        public short? AlcoholTotalYears { get; set; }

        [Required]
        public bool? UseTobacco { get; set; }

        public DateTime? TobaccoQuitDate { get; set; }

        [RequiredIf(nameof(UseTobacco), true)]
        public TobaccoFreqEnum? TobaccoFrequency { get; set; }

        [RequiredIf(nameof(UseTobacco), true)]
        public TobaccoFreqEnum? TobaccoPriorFreq { get; set; }

        [RequiredIf(nameof(UseTobacco), true)]
        public short? TobaccoTotalYears { get; set; }

        [Required]
        public bool? UseDrugs { get; set; }

        public DateTime? DrugsQuitDate { get; set; }

        [RequiredIf(nameof(UseDrugs), true)]
        public List<DrugFrequencyResponse> DrugFrequency { get; set; }

        [RequiredIf(nameof(UseDrugs), true)]
        public short? DrugsTotalYears { get; set; }

        [Required]
        public short? BirthsQty { get; set; }

        public short? MiscarriageQty { get; set; } 

        public short? AbortionQty { get; set; }

        //[RequiredIf(nameof(AbortionQty), Operator.GreaterThan ,0)]
        public AbortionTypeEnum? AbortionType { get; set; }

        //[RequiredIf(nameof(AbortionQty), Operator.GreaterThan, 0)]
        public DateTime? AbortionDate { get; set; }

        //[RequiredIf(nameof(AbortionQty), Operator.GreaterThan, 0)]
        public bool? AbortionIssues { get; set; }

        [Required]
        public bool? HavePlanB { get; set; }

        [RequiredIf(nameof(HavePlanB), true)]
        public short? PlanBQty { get; set; }

        [RequiredIf(nameof(HavePlanB), true)]
        public DateTime? LastPlanBDate { get; set; }

        [Required]
        public bool? HaveBirthControl { get; set; }

        [RequiredIf(nameof(HaveBirthControl), true)]
        public DateTime? BirthControlEnd { get; set; }

        [RequiredIf(nameof(HaveBirthControl), true)]
        public BirthControlEnum? BirthControlType { get; set; }

        [MaxLength(256, ErrorMessage = "* Maximum {1} characters")]
        [RequiredIf(nameof(BirthControlType), BirthControlEnum.Other)]
        public string? OtherBirthControlType { get; set; }

        [RequiredIf(nameof(HaveBirthControl), true)]
        public BirthControlLongEnum? BirthControlLong { get; set; }

        [Required]
        public short? SexualActive { get; set; }

        [Required]
        public short? SexualPartners { get; set; }

        [Required]
        public bool? HaveStdTest { get; set; }

        [Required]
        public List<STDTypesEnum> StdTypes { get; set; }

        [RequiredIf(nameof(HaveStdTest), true)]
        public DateTime? StdTestDate { get; set; }

        [RequiredIf(nameof(HaveStdTest), true)]
        public bool? StdTestResult { get; set; }

        [RequiredIf(nameof(StdTestResult), true)]
        public bool? HaveTreatment { get; set; }

        [RequiredIf(nameof(StdTestResult), true)]
        public bool? PartnerNotified { get; set; }

        [Required]
        public bool? AdversePrenatal { get; set; }

        [Required]
        public bool? HaveRapeAbuse { get; set; }

        [RequiredIf(nameof(HaveRapeAbuse), true)]
        public string? RapeAbuseNotes { get; set; }

        [Required]
        public virtual IntentionsEnum? Intentions { get; set; } 

        public bool? AdoptionOption { get; set; } 

        public AbortionRiskEnum? AbortionRisk { get; set; }
    }

}
