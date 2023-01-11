using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class UserForgotPasswordRequest

    {
        public string Email { get; set; } = string.Empty;

    }
    public class UserForgotPasswordValidator : AbstractValidator<UserForgotPasswordRequest>
    {

        public UserForgotPasswordValidator()
        {

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email address is not correct");
        }

    }
}
