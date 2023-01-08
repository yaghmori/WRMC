using WRMC.Core.Application.DataServices;
using WRMC.Core.Shared.Validators;

namespace WRMC.RootComponents.Validators
{
    public class TenantRemoteValidator : ITenantValidator  
    {
        private readonly ITenantDataService _tenantDataService;

        public TenantRemoteValidator(ITenantDataService tenantDataService)
        {
            _tenantDataService = tenantDataService;
        }

        public async Task<bool> CheckIfUniqueTenantName(string name, CancellationToken token)
        {
            bool isDupplicate = false;
            var response = await _tenantDataService.CheckIfNameExist(name);
            if (response.Succeeded)
            {
                isDupplicate = response.Data;
            }

            return !isDupplicate;
        }
    }

}
