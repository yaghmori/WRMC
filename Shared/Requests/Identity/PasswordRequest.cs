using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class PasswordRequest
    {
        public string Password { get; set; } = default!;
        public string PasswordConfirmation { get; set; } = default!;
    }

    public class PasswordValidator : AbstractValidator<PasswordRequest>
    {

        public PasswordValidator()
        {

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("This field is required")
                .Length(8, 24).WithMessage("Password must be at least 8 and maximum 24 characters long");
            RuleFor(x => x.PasswordConfirmation)
                .NotEmpty().WithMessage("Please confirm your password")
                .Length(8, 24).WithMessage("Password must be at least 8 and maximum 24 characters long")
                .Equal(x => x.Password).WithMessage("Passwords do not match");
        }

    }
}
