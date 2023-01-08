using WRMC.Core.Application.DataServices;
using WRMC.Core.Shared.Validators;

namespace WRMC.RootComponents.Validators
{
    public class UserRemoteValidator : IUserValidator
    {
        private readonly IUserDataService _userDataService;

        public UserRemoteValidator(IUserDataService userDataService)
        {
            _userDataService = userDataService;
        }

        public async Task<bool> CheckIfUniqueEmail(string email, CancellationToken token)
        {
            bool exist = false;
            var response = await _userDataService.CheckIfEmailExist(email);
            if (response.Succeeded)
            {
                exist = response.Data;
            }

            return !exist;
        }
    }

}
