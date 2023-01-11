using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Requests;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Dialogs
{
    public partial class AddOrUpdateRoleDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; }
        [Parameter] public string RoleId { get; set; } = string.Empty;
        public RoleRequest Model { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;
            if (!string.IsNullOrWhiteSpace(RoleId)) //load role
            {
                var result = await _roleDataService.GetRoleAsync(RoleId);
                if (result.Succeeded)
                {
                    Model = _autoMapper.Map<RoleRequest>(result.Data);
                }
                else
                {
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
            Model.RoleId= RoleId; //for remote validation

            IsLoading = false;
            StateHasChanged();
        }
        private async void SaveChangesSubmit(EditContext context)
        {
            IsBusy = true;
            bool dgResult = false;
            if (string.IsNullOrWhiteSpace(RoleId)) //New
            {
                var result = await _roleDataService.AddRoleAsync(Model.Name);
                if (result.Succeeded)
                {
                    var roleId = result.Data;
                    if (!string.IsNullOrWhiteSpace(roleId))
                    {
                        dgResult = true;
                        _snackbar.Add(_messageLocalizer[MessageResources.RoleSuccessfullyCreated], Severity.Success);
                    }
                }
                else
                {
                    _snackbar.Add(_messageLocalizer[MessageResources.CreatingRoleFailed], Severity.Error);
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Success);
                    }
                }
            }
            else //Edit
            {
                var result = await _roleDataService.UpdateRoleAsync(RoleId, Model.Name);
                if (result.Succeeded)
                {
                    dgResult = true;
                    _snackbar.Add(_messageLocalizer[MessageResources.RoleSuccessfullyUpdated], Severity.Success);
                }
                else
                {
                    _snackbar.Add(_messageLocalizer[MessageResources.UpdatingRoleFailed], Severity.Error);
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