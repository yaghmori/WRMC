using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Validators;
using WRMC.Infrastructure.Domain.Enums;
using WRMC.Infrastructure.Localization;

namespace WRMC.Core.Shared.Requests
{
    public class NewUserRequest : RegisterRequest
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public GenderEnum Gender { get; set; }


    }

    public class NewUserValidator : AbstractValidator<NewUserRequest>
    {

        public NewUserValidator(IUserValidator userValidator)
        {
            Include(new RegisterValidator(userValidator));

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Gender).NotNull().WithMessage("Gender is required");

        }

    }

}
