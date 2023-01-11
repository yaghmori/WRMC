using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using WRMC.Core.Shared.Requests;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Components
{
    public partial class ChangePassword
    {
        [Parameter]
        public string UserId { get; set; } = string.Empty;
        private ChangePasswordRequest changePasswordRequest { get; set; } = new();

        private bool IsBusy = false;
        private async void SubmitPasswordChangeAsync(EditContext context)
        {
            IsBusy = true;
            var result = await _userDataService.ChangePasswordAsync(UserId, changePasswordRequest);
            if (result.Succeeded)
            {
                context.MarkAsUnmodified();
                _snackbar.Add(_messageLocalizer[MessageResources.UserPasswordChangeSuccessfully], Severity.Success);
                changePasswordRequest = new();

                //TODO : Remove Tokens to disconnect from all devices
                //TODO : Use SignalR 
            }
            else
            {
                _snackbar.Add(_messageLocalizer[MessageResources.UserPassworNotUpdated], Severity.Error);
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }

            IsBusy = false;
            StateHasChanged();
        }
    }
}