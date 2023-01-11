using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Requests;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Dialogs
{
    public partial class UpdateUserDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; }
        [Parameter] public string UserId { get; set; } = string.Empty;
        public UserRequest User { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            var result = await _userDataService.GetUserAsync(UserId);
            User = new UserRequest();
            if (result.Succeeded)
            {
                User = _autoMapper.Map<UserRequest>(result.Data);
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }

            }
            IsLoading = false;
            StateHasChanged();
        }
        private async void SaveChangesSubmit(EditContext context)
        {
            IsBusy = true;
            var dgResult = false;
            var patchDoc = new JsonPatchDocument<UserRequest>();
            patchDoc.Replace(e => e.Email, User.Email);
            patchDoc.Replace(e => e.PhoneNumber, User.PhoneNumber);
            patchDoc.Replace(e => e.FirstName, User.FirstName);
            patchDoc.Replace(e => e.LastName, User.LastName);
            patchDoc.Replace(e => e.Image, User.Image);
            var result = await _userDataService.UpdateUserAsync(UserId, patchDoc);
            if (result.Succeeded)
            {
                dgResult = true;
                _snackbar.Add(_messageLocalizer[MessageResources.UserSuccessfullyUpdated].Value, Severity.Success);
            }
            else
            {

                _snackbar.Add(_messageLocalizer[MessageResources.UpdatingUserFailed].Value, Severity.Error);
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }

            IsBusy = false;
            MudDialog.Close(DialogResult.Ok(dgResult));
        }
        private void Cancel()
        {
            MudDialog.Cancel();
        }
    }

}