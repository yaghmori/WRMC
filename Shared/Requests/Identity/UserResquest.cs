using FluentValidation;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Validators;

namespace WRMC.Core.Shared.Requests
{
    public class UserRequest
    {
        public string? Id { get; set; }

        public string? ProfileName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public bool IsOnline { get; set; } = false;

        public string NormalizedEmail => Email.Normalize().ToUpper();
        public string NormalizedUserName => Email.Normalize().ToUpper();
        public string UserName => Email;


    }
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        private readonly IUserValidator _userValidator;

        public UserRequestValidator(IUserValidator userValidator)
        {
            _userValidator = userValidator;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("This field is required")
                .EmailAddress().WithMessage("Not valid email address")
                .MustAsync(BeUniqueEmail).WithMessage("Email already exist");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("This field is required");
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken token)
        {
            return await _userValidator.CheckIfUniqueEmail(email, token);
        }
    }


}
