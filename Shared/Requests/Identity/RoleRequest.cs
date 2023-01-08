using FluentValidation;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Validators;

namespace WRMC.Core.Shared.Requests
{
    public class RoleRequest
    {
        public string Name { get; set; }
    }
    public class RoleValidator : AbstractValidator<RoleRequest>
    {
        private readonly IRoleValidator _roleValidator;

        public RoleValidator(IRoleValidator roleValidator)
        {
            _roleValidator = roleValidator;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please specify role name")
                .MustAsync(BeUniqueEmail).WithMessage("Role name already exist");
        }
        private async Task<bool> BeUniqueEmail(string email, CancellationToken token)
        {
            return await _roleValidator.CheckIfUniqueRoleName(email, token);
        }

    }

}
