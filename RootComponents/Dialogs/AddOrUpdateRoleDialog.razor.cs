using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Requests;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Dialogs
{
    public partial class AddOrUpdateRoleDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] public HubConnection hubConnection { get; set; }
        [Parameter] public string RoleId { get; set; } = string.Empty;
        public RoleRequest Role { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            if (!string.IsNullOrWhiteSpace(RoleId))
            {
                var result = await _roleDataService.GetRoleAsync(RoleId);
                if (result.Succeeded)
                {
                    Role = _autoMapper.Map<RoleRequest>(result.Data);
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
            if (string.IsNullOrWhiteSpace(RoleId)) //New
            {
                var result = await _roleDataService.AddRoleAsync(Role.Name);
                if (result.Succeeded)
                {
                    var roleId = result.Data;
                    if (!string.IsNullOrWhiteSpace(roleId))
                    {
                        dgResult = true;
                        _snackbar.Add(_messageResources[MessageResources.RoleSuccessfullyCreated], Severity.Success);
                    }
                }
                else
                {
                    _snackbar.Add(_messageResources[MessageResources.CreatingRoleFailed], Severity.Error);
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Success);
                    }
                }
            }
            else //Edit
            {
                var result = await _roleDataService.UpdateRoleAsync(RoleId, Role.Name);
                if (result.Succeeded)
                {
                    dgResult = true;
                    _snackbar.Add(_messageResources[MessageResources.RoleSuccessfullyUpdated], Severity.Success);
                    //Get RoleUsers 
                    var usersResponse = await _roleDataService.GetUserRolesAsync(RoleId);
                    if (usersResponse.Succeeded)
                    {
                        //SignalR
                        var users = usersResponse.Data.Select(x => x.Id).ToList();
                        if (hubConnection is not null)
                        {
                            await hubConnection.SendAsync(EndPoints.Hub.SendUpdateAuthState, users);
                        }
                    }


                }
                else
                {
                    _snackbar.Add(_messageResources[MessageResources.UpdatingRoleFailed], Severity.Error);
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