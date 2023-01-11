using System.Security.AccessControl;
using FluentValidation;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;

namespace WRMC.Core.Shared.Requests
{
    public class DemographicIntakeRequest : IntakeBaseRequest
    {
        public ResidentialIntakeRequest ResidentialIntake { get; set; }=new ResidentialIntakeRequest();
        public FinancialIntakeRequest FinancialIntake { get; set; } = new FinancialIntakeRequest();
        public OtherDemographicIntakeRequest OtherDemographicIntake { get; set; } = new OtherDemographicIntakeRequest();

    }



    public class DemographicIntakeValidator : AbstractValidator<DemographicIntakeRequest>
    {
        public DemographicIntakeValidator()
        {
            Include(new IntakeBaseValidator());
            RuleFor(x => x.ResidentialIntake).SetValidator(new ResidentialIntakeValidator());
            RuleFor(x => x.FinancialIntake).SetValidator(new FinancialIntakeValidator());
            RuleFor(x => x.OtherDemographicIntake).SetValidator(new OtherIntakeValidator());
            RuleFor(x => x.IsComplete).Equal(true).WithMessage("Please accept terms and conditions");
        }
    }


    public class ResidentialIntakeRequest
    {

        #region Residential 
        //Residential
        public bool? IsUSCitizen { get; set; }
        public ImmigrationStatusEnum? ImmigrationStatus { get; set; }
        public string? RegionId { get; set; }
        private RegionResponse region { get; set; }
        public RegionResponse Region
        {
            get { return region; }
            set
            {
                region = value;
                RegionId = value?.Id;
            }
        }


    
        public MaritalEnum? MaritalStatus { get; set; }
        public LivingEnum? LivingArrangement { get; set; }
        public short? NumberOfHousehold { get; set; }
        //Insurance
        public bool? HaveInsurance { get; set; }
        public InsuranceNameEnum? InsuranceName { get; set; }
        public string? MedicaidNo { get; set; }
        public bool? NeedInsurance { get; set; }
        //Educational
        public bool? InSchool { get; set; }
        public LastGradeEnum? LastGrade { get; set; }
        public string? SchoolName { get; set; }
        #endregion

    }
    public class FinancialIntakeRequest
    {
        #region Financial
        public EmploymentEnum? Employment { get; set; }
        public string? Employer { get; set; }
        public string? Occupation { get; set; }
        public IncomeEnum? Income { get; set; }
        public bool? CombinedIncome { get; set; }
        public short? NumberOfTaxReturn { get; set; }
        public string? FinancialSupport { get; set; }
        #endregion

    }
    public class OtherDemographicIntakeRequest
    {

        #region Other
        public GenderEnum? Gender { get; set; }
        public bool? Disabled { get; set; }
        public bool? AffordPrenatal { get; set; }
        public bool? UndueBurden { get; set; }
        public bool? ConduciveRaising { get; set; }
        public bool? HidePregnancy { get; set; }
        #endregion

    }

    public class ResidentialIntakeValidator : AbstractValidator<ResidentialIntakeRequest>
    {
        public ResidentialIntakeValidator()
        {            //Residential
            RuleFor(x => x.SchoolName).NotEmpty().When(x => x.InSchool == true).WithMessage("Please specify school name");
            RuleFor(x => x.InSchool).NotEmpty().WithMessage("Please specify if you are currently studying at school");
            RuleFor(x => x.IsUSCitizen).NotEmpty().WithMessage("Please specify if you are a US citizen");
            RuleFor(x => x.ImmigrationStatus).NotEmpty().When(x => x.IsUSCitizen == false).WithMessage("Please specify your immigration status");
            RuleFor(x => x.Region).NotNull().When(x => x.IsUSCitizen == false).WithMessage("Please specify your country");
            RuleFor(x => x.LivingArrangement).NotEmpty().WithMessage("Please specify living arrangement");
            RuleFor(x => x.NumberOfHousehold).NotEmpty().WithMessage("Please specify number of household");
            RuleFor(x => x.HaveInsurance).NotEmpty().WithMessage("Please specify if you currently have insurance");
            RuleFor(x => x.InsuranceName).NotEmpty().When(x => x.HaveInsurance == true).WithMessage("Please specify the insurance name");
            RuleFor(x => x.MedicaidNo).NotEmpty().When(x => x.HaveInsurance == true).WithMessage("Please specify your Medicaid number");
            RuleFor(x => x.NeedInsurance).NotEmpty().When(x => x.HaveInsurance == false).WithMessage("This filed is required");

        }
    }
    public class FinancialIntakeValidator : AbstractValidator<FinancialIntakeRequest>
    {
        public FinancialIntakeValidator()
        {
            //Financial 

            RuleFor(x => x.Employment).NotEmpty().WithMessage("Please specify your employment status");
            RuleFor(x => x.Employer).NotEmpty().When(x => Enum.GetValues(typeof(EmployerRequiredEnum)).Cast<short>().Any(a => a == (short?)x.Employment)).WithMessage("Please specify your employer name");
            RuleFor(x => x.Occupation).NotEmpty().When(x => Enum.GetValues(typeof(OccupationRequiredEnum)).Cast<short>().Any(a => a == (short?)x.Employment)).WithMessage("Please specify your Occupation");
            RuleFor(x => x.Income).NotEmpty().WithMessage("Please specify your income range");
            RuleFor(x => x.CombinedIncome).NotEmpty().When(x => x.Income == IncomeEnum.NoIncome).WithMessage("This filed is required");
            RuleFor(x => x.NumberOfTaxReturn).NotEmpty().WithMessage(ValidationResources.Required).WithMessage("This filed is required");
            RuleFor(x => x.FinancialSupport).NotEmpty().WithMessage(ValidationResources.Required).WithMessage("This filed is required");

        }
    }
    public class OtherIntakeValidator : AbstractValidator<OtherDemographicIntakeRequest>
    {
        public OtherIntakeValidator()
        {            //Other 

            RuleFor(x => x.AffordPrenatal).NotEmpty().WithMessage(ValidationResources.Required).WithMessage("This filed is required");
            RuleFor(x => x.UndueBurden).NotEmpty().WithMessage(ValidationResources.Required).WithMessage("This filed is required");
            RuleFor(x => x.ConduciveRaising).NotEmpty().WithMessage(ValidationResources.Required).WithMessage("This filed is required");
            RuleFor(x => x.HidePregnancy).NotEmpty().When(x => x.Gender == GenderEnum.Female).WithMessage(ValidationResources.Required).WithMessage("This filed is required");
            RuleFor(x => x.Disabled).NotEmpty().WithMessage(ValidationResources.Required).WithMessage("This filed is required");

        }
    }

}
