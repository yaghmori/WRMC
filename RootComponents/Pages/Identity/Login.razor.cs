using MudBlazor;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Requests;

namespace WRMC.RootComponents.Pages.Identity
{
    public partial class Login
    {
        public LoginByEmailRequest Request = new();
        public bool IsBusy = false;
        public bool PasswordVisibility { get; set; } = false;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

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

        private async Task OnSubmitAsync()
        {
            var result = await _authDataService.GetTokenAsync(Request);
            if (result.Succeeded)
            {
                await ((AuthStateProvider)_authStateProvider).NotifyLoginAsync(result.Data, Request.IsPersistent);
                _navigationManager.NavigateTo(AppURL.Index, true);

            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
        }

    }
}