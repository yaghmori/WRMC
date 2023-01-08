using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class SignInByUserNameRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        [RegularExpression("([0-9]+)")]
        public bool IsPersistent { get; set; }
        public string NormalizedUsername => Username.Normalize().ToUpper();

    }
    public class SignInByPhoneNumberRequest
    {
        [Required]
        [RegularExpression("([0-9]+)")]
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsPersistent { get; set; }
    }
    public class LoginByEmailRequest
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        
        public bool IsPersistent { get; set; }
    }
    public class LoginByEmailValidator : AbstractValidator<LoginByEmailRequest>
    {

        public LoginByEmailValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("This field is required")
                .EmailAddress().WithMessage("Not valid email address");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("This field is required")
                .Length(8, 24).WithMessage("Password must be at least 8 and maximum 24 characters long");
        }
    }

}
