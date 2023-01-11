using FluentValidation;
using System.ComponentModel.DataAnnotations;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Core.Shared.Requests
{
    public class UserPhoneNumberRequest
    {


        public  PhoneNumberTypeEnum? Type { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string? Description { get; set; }
        public bool IsDefault { get; set; } = false;
        public int? Order { get; set; }
    }
    public class UserPhoneNumberValidator : AbstractValidator<UserPhoneNumberRequest>
    {

        public UserPhoneNumberValidator()
        {

            RuleFor(x => x.Type).NotNull().WithMessage("Type is required");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required");
        }

    }
}
