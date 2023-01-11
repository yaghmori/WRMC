using Microsoft.Extensions.Localization;
using MudBlazor;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Requests;

namespace WRMC.RootComponents.Pages.Identity
{
    public partial class Register
    {
        public bool AgreeToTerms { get; set; } = false;
        bool hasErrors => errors.Length > 0 ? true : false;
        string[] errors = {};
        bool PasswordVisibility;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        InputType PasswordInput = InputType.Password;
        void TogglePasswordVisibility()
        {
            if (PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

        RegisterRequest model = new();
        private async Task OnSubmitAsync()
        {
            var registerResponse = await _authDataService.RegisterAsync(model);
            
            if (registerResponse.Succeeded)
            {
                var tokenRequest = new LoginByEmailRequest()
                {
                    Email = model.Email,
                    Password = model.Password,
                    IsPersistent = false
                };
                var tokenResponse = await _authDataService.GetTokenAsync(tokenRequest);
                if (tokenResponse.Succeeded)
                {
                    _snackbar.Add(_messageLocalizer.GetString("RegisterSuccessfull").Value, Severity.Success);
                    await ((AuthStateProvider)_authStateProvider).NotifyLoginAsync(tokenResponse.Data, false);
                    _navigationManager.NavigateTo(AppURL.Index, true);

                }
            }
            else
            {
                await ((AuthStateProvider)_authStateProvider).NotifyLogoutAsync();
                foreach (var messages in registerResponse.Messages)
                {
                    _snackbar.Add(_messageLocalizer.GetString(messages).Value, Severity.Error);
                }
            }
        }
    }
}