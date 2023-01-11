using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ValidationAttributes;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests
{
    public class MedicalIntakeRequest : IntakeBaseRequest
    {

       
        public bool? IsPeriodRemember { get; set; }
        public DateTime? LastPeriodDate { get; set; }
        public bool? HaveNormalPeriod { get; set; }
        public string? NormalPeriodNote { get; set; }
        public short? FirstMenstrualAge { get; set; }
        public DateTime? LastSexIntercourse { get; set; } 
        public List<SymptomsEnum> Symptoms { get; set; }


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

      
        public List<DrugFrequencyResponse> DrugFrequency { get; set; }

     
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

 
        public List<STDTypesEnum> StdTypes { get; set; }

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
    }
    public class MedicalIntakeValidator : AbstractValidator<MedicalIntakeRequest>
    {
        public MedicalIntakeValidator()
        {
            //RuleFor(x => x.ResidentialIntake).SetValidator(new ResidentialIntakeValidator());
            //RuleFor(x => x.FinancialIntake).SetValidator(new FinancialIntakeValidator());
            //RuleFor(x => x.OtherDemographicIntake).SetValidator(new OtherIntakeValidator());

            //RuleFor(x => x.VisitId).NotEmpty().WithMessage("Please specify a Visit Id");
            //RuleFor(x => x.TaskId).NotEmpty().WithMessage("Please specify a Task Id");
            //RuleFor(x => x.Gender).NotEmpty().WithMessage("Please specify your gender");
            //RuleFor(x => x.DemographicAccepted).Must(x => x == true).WithMessage("Please accept terms and conditions");

            Include(new IntakeBaseValidator());
            RuleFor(x => x.IsPeriodRemember).NotEmpty().WithMessage("This field is required");
            RuleFor(a => a.LastPeriodDate).LessThanOrEqualTo(DateTime.Today).GreaterThanOrEqualTo(DateTime.Today.AddMonths(-6)).When(d => d.LastPeriodDate != null).WithMessage("Enter a valid date for last period date");

            RuleFor(x => x.HaveNormalPeriod).NotEmpty().When(x=>x.IsPeriodRemember==true).WithMessage("Please specify if you have normal period");
            RuleFor(x => x.NormalPeriodNote).NotEmpty().When(x=>x.HaveNormalPeriod == true).WithMessage("This field is required");
            RuleFor(x => x.FirstMenstrualAge).NotEmpty().WithMessage("Please specify your first menstrual age");
            RuleFor(x => x.LastSexIntercourse).NotEmpty().WithMessage("Please specify your last sex intercourse date");
            RuleFor(x => x.MedicalConditions).NotEmpty().WithMessage("Please specify your medical conditions");
            RuleFor(x => x.MedicalConditionsNote).NotEmpty().When(x=>x.MedicalConditions==true).WithMessage("This field is required");
            RuleFor(x => x.DoctorCare).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.Medication).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.MedicationType).NotEmpty().When(x=>x.Medication==true).WithMessage("This field is required");
            RuleFor(x => x.BlackboxMedication).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.HavePapSmear).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.LastExaminationDate).NotEmpty().When(x=>x.HavePapSmear==true).WithMessage("This field is required");
            RuleFor(x => x.UseAlcohol).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.AlcoholFrequency).NotEmpty().When(x => x.UseAlcohol == true).WithMessage("This field is required");
            RuleFor(x => x.AlcoholPriorFreq).NotEmpty().When(x => x.UseAlcohol == true).WithMessage("This field is required");
            RuleFor(x => x.AlcoholTotalYears).NotEmpty().When(x => x.UseAlcohol == true).WithMessage("This field is required");
            RuleFor(x => x.UseTobacco).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.TobaccoFrequency).NotEmpty().When(x => x.UseTobacco == true).WithMessage("This field is required");
            RuleFor(x => x.TobaccoPriorFreq).NotEmpty().When(x => x.UseTobacco == true).WithMessage("This field is required");
            RuleFor(x => x.TobaccoTotalYears).NotEmpty().When(x => x.UseTobacco == true).WithMessage("This field is required");
            RuleFor(x => x.UseDrugs).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.DrugFrequency).NotEmpty().When(x => x.UseDrugs == true).WithMessage("This field is required");
            RuleFor(x => x.DrugsTotalYears).NotEmpty().When(x => x.UseDrugs == true).WithMessage("This field is required");
            RuleFor(x => x.BirthsQty).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.HavePlanB).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.PlanBQty).NotEmpty().When(x => x.HavePlanB == true).WithMessage("This field is required");
            RuleFor(x => x.LastPlanBDate).NotEmpty().When(x => x.HavePlanB == true).WithMessage("This field is required");
            RuleFor(x => x.HaveBirthControl).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.BirthControlType).NotEmpty().When(x => x.HaveBirthControl == true).WithMessage("This field is required");
            RuleFor(x => x.BirthControlLong).NotEmpty().When(x => x.HaveBirthControl == true).WithMessage("This field is required");
            RuleFor(a => a.OtherBirthControlType).NotEmpty().When(d => d.BirthControlType == BirthControlEnum.BirthControlPill).WithMessage("Please specify Birth Control Type");

            RuleFor(x => x.SexualActive).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.SexualPartners).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.HaveStdTest).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.StdTypes).NotEmpty().When(x => x.HaveStdTest == true).WithMessage("This field is required");
            RuleFor(x => x.StdTestDate).NotEmpty().When(x => x.HaveStdTest == true).WithMessage("This field is required");
            RuleFor(x => x.StdTestResult).NotEmpty().When(x => x.HaveStdTest == true).WithMessage("This field is required");
            RuleFor(x => x.HaveTreatment).NotEmpty().When(x => x.StdTestResult == true).WithMessage("This field is required");
            RuleFor(x => x.PartnerNotified).NotEmpty().When(x => x.StdTestResult == true).WithMessage("This field is required");
            RuleFor(x => x.AdversePrenatal).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.HaveRapeAbuse).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.RapeAbuseNotes).NotEmpty().When(x => x.HaveRapeAbuse == true).WithMessage("This field is required");
            RuleFor(x => x.Intentions).NotEmpty().When(x => x.HaveRapeAbuse == true).WithMessage("This field is required");

            RuleFor(a => a.AbortionRisk).NotEmpty().When(d => d.Intentions is IntentionsEnum.Unsure or IntentionsEnum.Abortion).WithMessage("Please specify AbortionRisk");
            RuleFor(a => a.OtherSymptoms).NotEmpty().When(d => d.Symptoms != null && d.Symptoms.Any(a=>a==SymptomsEnum.Other)).WithMessage("Please specify Symptoms");
            RuleFor(a => a.AbortionType).NotEmpty().When(d => d.AbortionQty > 0).WithMessage("Please specify abortion type");
            RuleFor(a => a.AbortionDate).NotEmpty().When(d => d.AbortionQty  > 0).WithMessage("Please specify abortion date");
            RuleFor(a => a.AbortionIssues).NotEmpty().When(d => d.AbortionQty  > 0).WithMessage("Please specify abortion issues");
            RuleFor(a => a.AdoptionOption).NotEmpty().When(d => d.Intentions !=IntentionsEnum.Unsure).WithMessage("Please specify adoption option");

        }

    }
}
