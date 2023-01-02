using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Requests;
using WRMC.Infrastructure.Localization;

namespace WRMC.RootComponents.Dialogs
{
    public partial class AddOrUpdateTenantDialog
    {
        [CascadingParameter] public MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] public HubConnection hubConnection { get; set; }
        [Parameter] public string TenantId { get; set; } = string.Empty;
        public string DefaultConnectionString { get; set; } = string.Empty;
        public TenantRequest Tenant { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true;

            if (!string.IsNullOrWhiteSpace(TenantId))
            {
                var result = await _TenantDataService.GetTenantByIdAsync(TenantId);
                if (result.Succeeded)
                {
                    Tenant = _autoMapper.Map<TenantRequest>(result.Data);
                }
                else
                {
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
            else
            {
                var appsettingsResponse = await _appSettingDataService.GetAppSettingsByKeyAsync(ApplicationConstants.DefaultConnectionString);
                if (appsettingsResponse.Succeeded)
                {
                    Tenant.ConnectionString = appsettingsResponse.Data.Value;
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
            IsSaving = true;
            bool dgResult = false;

            if (string.IsNullOrWhiteSpace(TenantId)) //New
            {
                var result = await _TenantDataService.AddTenantAsync(Tenant);
                if (result == null)
                    return;
                if (result.Succeeded)
                {
                    var tenantId = result.Data;
                    var createDatabaseResult = await _TenantDataService.CreateDatabaseAsync(tenantId);
                    if (createDatabaseResult.Succeeded)
                    {
                        dgResult = true;
                        _snackbar.Add(_messageResources[MessageResources.ClientSuccessfullyCreated].Value, Severity.Success);
                    }
                    else
                    {
                        dgResult = false;
                        await _TenantDataService.DeleteTenantByIdAsync(tenantId);
                        _snackbar.Add(_messageResources[MessageResources.CreatingClientFailed].Value, Severity.Error);
                        foreach (var message in createDatabaseResult.Messages)
                        {
                            _snackbar.Add(message, Severity.Error);
                        }
                    }
                }
                else
                {
                    dgResult = false;
                    _snackbar.Add(_messageResources[MessageResources.CreatingClientFailed].Value, Severity.Error);
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
            else //Edit
            {
                var patchDoc = new JsonPatchDocument<TenantRequest>();
                patchDoc.Replace(e => e.Name, Tenant.Name);
                patchDoc.Replace(e => e.Description, Tenant.Description);
                patchDoc.Replace(e => e.ExpireDate, Tenant.ExpireDate);
                patchDoc.Replace(e => e.ConnectionString, Tenant.ConnectionString);
                var result = await _TenantDataService.UpdateTenantByIdAsync(TenantId, patchDoc);

                if (result.Succeeded)
                {
                    dgResult = true;
                    _snackbar.Add(_messageResources[MessageResources.ClientSuccessfullyUpdated].Value, Severity.Success);

                    //SignalR
                    var usersResponse = await _TenantDataService.GetTenantUsersAsync(TenantId);
                    if (usersResponse.Succeeded)
                    {
                        var users = usersResponse.Data.Select(x => x.Id).ToList();
                        if (hubConnection is not null)
                        {
                            await hubConnection.SendAsync(EndPoints.Hub.SendUpdateAuthState, users);
                        }
                    }
                }
                else
                {
                    dgResult = false;
                    _snackbar.Add(_messageResources[MessageResources.UpdatingClientFailed].Value, Severity.Error);

                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }

            IsSaving = false;
            MudDialog.Close(DialogResult.Ok(dgResult));
        }
        private void Cancel()
        {
            MudDialog.Cancel();
        }

    }
}