using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using WRMC.Core.Shared.Helpers;
using WRMC.Core.Shared.Requests;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Dialogs
{
    public partial class CreateNewUserDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }
        public NewUserRequest NewUserRequest { get; set; } = new();
        private void Cancel()
        {
            MudDialog.Cancel();
        }

        private void GenerateRandomPassword()
        {
            NewUserRequest.Password = PasswordHelper.GeneratePassword(8);
            NewUserRequest.PasswordConfirmation = NewUserRequest.Password;
        }
        async void SaveChangesSubmit(EditContext context)
        {
            IsBusy = true;

            var result = await _userDataService.CreateNewUserAsync(NewUserRequest);
            if (result.Succeeded)
            {
                _snackbar.Add(_messageLocalizer[MessageResources.UserSuccessfullyCreated], Severity.Success);
            }
            else
            {
                _snackbar.Add(_messageLocalizer[MessageResources.CreatingUserFailed], Severity.Error);
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }


            IsBusy = false;
            MudDialog.Close(DialogResult.Ok(result.Data));
        }
    }
}