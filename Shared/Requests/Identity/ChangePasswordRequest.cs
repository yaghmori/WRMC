using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class ChangePasswordRequest : PasswordRequest
    {

        public string CurrentPassword { get; set; } = default!;


    }
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            Include(new PasswordValidator());

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("This field is required");
        }
    }

}
