using WRMC.Core.Shared.Validators;
using WRMC.Infrastructure.UnitOfWork;

namespace WRMC.Server.Validators
{
    public class TenantRemoteValidator : ITenantValidator  
    {
        private readonly IUnitOfWork _unitOfWork;

        public TenantRemoteValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<bool> CheckIfUniqueTenantName(string name, CancellationToken token)
        {
            return await _unitOfWork.Tenants.AnyAsync(x => x.Name.Equals(name));
        }
    }

}
