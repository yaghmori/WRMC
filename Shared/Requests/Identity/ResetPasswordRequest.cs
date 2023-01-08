using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Validators;

namespace WRMC.Core.Shared.Requests
{
    public class ResetPasswordRequest : PasswordRequest

    {
        public string Token { get; set; } = default!;


    }

    public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {

        public ResetPasswordRequestValidator()
        {
            Include(new PasswordValidator());
            RuleFor(x => x.Token).NotEmpty().WithMessage("Token is not provided");
        }

    }

}
