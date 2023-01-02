using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Requests;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Dialogs
{
    public partial class AddOrUpdatePhoneNumberDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] public HubConnection hubConnection { get; set; }
        [Parameter] public string UserPhoneNumberId { get; set; } = string.Empty;
        [Parameter] public string UserId { get; set; } = string.Empty;
        public UserPhoneNumberRequest UserPhoneNumber { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            if (!string.IsNullOrWhiteSpace(UserPhoneNumberId))
            {
                var result = await _userDataService.GetUserPhoneNumberAsync(UserId, UserPhoneNumberId);
                if (result.Succeeded)
                {
                    UserPhoneNumber = _autoMapper.Map<UserPhoneNumberRequest>(result.Data);
                }
                else
                {
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
            IsLoading = false;
            StateHasChanged();
        }
        private async void SaveChangesSubmit(EditContext context)
        {
            IsBusy = true;
            bool dgResult = false;
            if (string.IsNullOrWhiteSpace(UserPhoneNumberId)) //New
            {
                var result = await _userDataService.AddUserPhoneNumberAsync(UserId,UserPhoneNumber);
                if (result.Succeeded)
                {
                    var PhoneNumberId = result.Data;
                    if (!string.IsNullOrWhiteSpace(PhoneNumberId))
                    {
                        dgResult = true;
                        _snackbar.Add(_messageResources[MessageResources.PhoneNumberSuccessfullyAdded]?.Value, Severity.Success);

                        //TODO : Using SignalR
                    }
                }
                else
                {
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Success);
                    }
                }
            }
            else //Edit
            {
                var patchDoc = new JsonPatchDocument<UserPhoneNumberRequest>();
                patchDoc.Replace(e => e.PhoneNumber,UserPhoneNumber.PhoneNumber);
                patchDoc.Replace(e => e.PhoneNumberType,UserPhoneNumber.PhoneNumberType);
                patchDoc.Replace(e => e.Description,UserPhoneNumber.Description);
                patchDoc.Replace(e => e.IsDefault,UserPhoneNumber.IsDefault);


                var result = await _userDataService.UpdateUserPhoneNumberAsync(UserId, UserPhoneNumberId, patchDoc);
                if (result.Succeeded)
                {
                    dgResult = true;
                    _snackbar.Add(_messageResources[MessageResources.PhoneNumberSuccessfullyUpdated], Severity.Success);

                    //TODO : Using SignalR
                }
                else
                {
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Success);
                    }

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