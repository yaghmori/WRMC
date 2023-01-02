using FluentValidation;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;

namespace WRMC.Core.Shared.Requests
{
    public class DemographicIntakeRequestValidator : AbstractValidator<DemographicIntakeRequest>
    {
        public DemographicIntakeRequestValidator()
        {
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.VisitId).NotEmpty().WithMessage("Please specify a Visit Id");
            RuleFor(x => x.SchoolName).NotEmpty().When(x => x.InSchool == true);
            RuleFor(x => x.InSchool).NotNull().WithMessage(ValidationResources.OriginCountryFieldIsRequired);
            RuleFor(x => x.IsUSCitizen).NotNull();
            RuleFor(x => x.IsUSCitizen).NotNull();
            RuleFor(x => x.ImmigrationStatus).NotNull().When(x=>x.IsUSCitizen==false).WithMessage(ValidationResources.Required);
            RuleFor(x => x.Region).NotNull().When(x=>x.IsUSCitizen==false).WithMessage(ValidationResources.Required);
            RuleFor(x => x.LivingArrangement).NotNull();
            RuleFor(x => x.Employment).NotNull();
            RuleFor(x => x.Employer).NotNull().When(x=> Enum.GetValues(typeof(EmployerRequiredEnum)).Cast<short>().Any(a=>a==(short?)x.Employment));
            RuleFor(x => x.Occupation).NotNull().When(x=> Enum.GetValues(typeof(OccupationRequiredEnum)).Cast<short>().Any(a => a == (short?)x.Employment));
            RuleFor(x => x.Income).NotNull();
            RuleFor(x => x.CombinedIncome).NotNull().When(x => x.Income == IncomeEnum.NoIncome).WithMessage(ValidationResources.Required);
            RuleFor(x => x.HaveInsurance).NotNull();
            RuleFor(x => x.InsuranceName).NotNull().When(x => x.HaveInsurance == true).WithMessage(ValidationResources.Required);
            RuleFor(x => x.MedicaidNo).NotNull().When(x => x.HaveInsurance == true).WithMessage(ValidationResources.Required);
            RuleFor(x => x.NeedInsurance).NotNull().When(x => x.HaveInsurance == false).WithMessage(ValidationResources.Required);
            RuleFor(x => x.NumberOfTaxReturn).NotNull().WithMessage(ValidationResources.Required);
            RuleFor(x => x.NUmberOfHousehold).NotNull().WithMessage(ValidationResources.Required);
            RuleFor(x => x.Disabled).NotNull().WithMessage(ValidationResources.Required);
            RuleFor(x => x.Disabled).NotNull().WithMessage(ValidationResources.Required);
            RuleFor(x => x.DemographicAccepted).Must(x=>x==true).WithMessage(ValidationResources.Required);
            RuleFor(x => x.FinancialSupport).NotNull().WithMessage(ValidationResources.Required);
            RuleFor(x => x.AffordPrenatal).NotNull().WithMessage(ValidationResources.Required);
            RuleFor(x => x.UndueBurden).NotNull().WithMessage(ValidationResources.Required);
            RuleFor(x => x.ConduciveRaising).NotNull().WithMessage(ValidationResources.Required);
            RuleFor(x => x.HidePregnancy).NotNull().When(x=>x.Gender==GenderEnum.Female).WithMessage(ValidationResources.Required);


        }

    }

}
