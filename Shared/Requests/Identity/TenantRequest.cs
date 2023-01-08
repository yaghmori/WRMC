using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WRMC.Core.Shared.Validators;

namespace WRMC.Core.Shared.Requests
{
    public class TenantRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public string ConnectionString { get; set; }= string.Empty;
        public DateTime? ExpireDate { get; set; }

        //=========== Computed Field ==============================
        public string NormalizedName => Name.Normalize().ToUpper();

    }
    public class TenantValidator : AbstractValidator<TenantRequest>
    {

        private readonly ITenantValidator _tenantValidator;

        public TenantValidator(ITenantValidator tenantValidator)
        {
            _tenantValidator = tenantValidator;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Please specify tenant name")
                .MustAsync(BeUniqueName).WithMessage("Tenant name already exist");

            RuleFor(x => x.ConnectionString).NotEmpty().WithMessage("Please specify connection string");
            RuleFor(x => x.ExpireDate).NotEmpty().WithMessage("This field is required");
        }
        private async Task<bool> BeUniqueName(string email, CancellationToken token)
        {
            return await _tenantValidator.CheckIfUniqueTenantName(email, token);
        }

    }
}
