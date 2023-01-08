using FluentValidation;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Validators;

namespace WRMC.Core.Shared.Requests
{
    public class RegisterRequest : PasswordRequest
    {
        public string Email { get; set; } = string.Empty;
        
        //==========computed
        public string NormalizedEmail => Email.Normalize().ToUpper();
        public string UserName => Email;
        public string NormalizedUserName => UserName.Normalize().ToUpper();
        public string SecurityStamp => Guid.NewGuid().ToString();
        public string ConcurrencyStamp => Guid.NewGuid().ToString();

    }
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        private readonly IUserValidator _userValidator;

        public RegisterValidator(IUserValidator userValidator)
        {
            _userValidator = userValidator;
            Include(new PasswordValidator());

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("This field is required")
                .EmailAddress().WithMessage("Not valid email address")
                .MustAsync(BeUniqueEmail).WithMessage("Email already exist");//Remote validation
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken token)
        {
            return await _userValidator.CheckIfUniqueEmail(email, token);
        }
    }

}
