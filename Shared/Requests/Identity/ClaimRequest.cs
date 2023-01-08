using FluentValidation;
using WRMC.Core.Shared.Validators;

namespace WRMC.Core.Shared.Requests
{
    public class ClaimRequest
    {


        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
    public class ClaimValidator : AbstractValidator<ClaimRequest>
    {

        public ClaimValidator()
        {

            RuleFor(x => x.ClaimType).NotEmpty().WithMessage("Claim type is required");
            RuleFor(x => x.ClaimValue).NotEmpty().WithMessage("Claim value is required");

        }

    }
}
