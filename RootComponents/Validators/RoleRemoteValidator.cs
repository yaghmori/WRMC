using WRMC.Core.Application.DataServices;
using WRMC.Core.Shared.Validators;

namespace WRMC.RootComponents.Validators
{
    public class RoleRemoteValidator : IRoleValidator
    {
        private readonly IRoleDataService _roleDataService;

        public RoleRemoteValidator(IRoleDataService roleDataService)
        {
            _roleDataService = roleDataService;
        }


        public async Task<bool> CheckIfUniqueRoleName(string name, CancellationToken token)
        {
            bool exist = false;
            var response = await _roleDataService.CheckIfNameExist(name);
            if (response.Succeeded)
            {
                exist = response.Data;
            }

            return !exist;
        }
    }

}
