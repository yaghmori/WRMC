using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Dialogs;
using WRMC.RootComponents.Shared;

namespace WRMC.RootComponents.Pages.Tenants
{
    public partial class Tenants
    {
        [CascadingParameter] private HubConnection? _hubConnection { get; set; }

        public IPagedList<TenantResponse> TenantPagedCollection = new PagedList<TenantResponse>();

        private MudDataGrid<TenantResponse>? _mudDataGrid;
        private string Query { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            _appState.SetAppTitle(_viewResources[ViewResources.Tenants]);
            if (_hubConnection.State == HubConnectionState.Disconnected)
            {
                await _hubConnection.StartAsync();
            }
        }

        public async Task AddRemoveUsers(TenantResponse tenant)
        {
            var parameters = new DialogParameters { { "TenantId", tenant.Id } };
            var options = new DialogOptions()
            { CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = _dialog.Show<TenantUsersDialog>(_viewResources[ViewResources.Tenant] + " : " + tenant.Name, parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                if (_hubConnection is not null)
                {
                    await _hubConnection.SendAsync(EndPoints.Hub.SendUpdateAuthState, null);
                }

                await _mudDataGrid?.ReloadServerData();
            }
        }


        public async Task AddOrUpdateTenant(TenantResponse item)
        {
            var parameters = new DialogParameters();
            var title = "";
            if (item != null)
            {
                parameters.Add("TenantId", item.Id);
                title = _viewResources[ViewResources.UpdateTenant];
                var userResponse = await _TenantDataService.GetTenantUsersAsync(item.Id);
                if (userResponse.Succeeded)
                {
                    List<string> users = userResponse.Data.Select(x => x.Id).ToList();
                    if (_hubConnection is not null)
                    {
                        await _hubConnection.SendAsync(EndPoints.Hub.SendUpdateAuthState, users);
                    }
                }
            }
            else
            {
                parameters.Add("TenantId", string.Empty);
                title = _viewResources[ViewResources.CreateNewTenant];
            }

            var options = new DialogOptions()
            { CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = _dialog.Show<AddOrUpdateTenantDialog>(title, parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await _mudDataGrid.ReloadServerData();
            }
        }

        public async Task DeleteTenant(TenantResponse tenant)
        {
            var ContentText = _messageResources[MessageResources.DoYouReallyWantToDeleteClient];
            var ButtonText = _viewResources[ViewResources.Delete];
            var parameters = new DialogParameters
            {
                { "Title", tenant.Name },
                { "ButtonText", ButtonText },
                { "ContentText", ContentText },
                { "ButtonColor", Color.Error },
                { "ButtonIcon", Icons.Rounded.Delete },
                { "TitleIcon", Icons.Rounded.Delete },
            };
            var options = new DialogOptions()
            {
                CloseButton = true,
                MaxWidth = MaxWidth.ExtraSmall
            };

            //Get list of TenantUsers before delete tenant
            var userResponse = await _TenantDataService.GetTenantUsersAsync(tenant.Id);

            var dialog = _dialog.Show<MessageDialog>("", parameters, options);
            var dgResult = await dialog.Result;
            if (!dgResult.Cancelled)
            {

                var deleteDatabaseResponse = await _TenantDataService.DeleteDatabaseAsync(tenant.Id);
                if (!deleteDatabaseResponse.Succeeded)
                {
                    foreach (var message in deleteDatabaseResponse.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }

                var deleteResponse = await _TenantDataService.DeleteTenantByIdAsync(tenant.Id);
                if (deleteResponse != null)
                {
                    //SignalR
                    if (userResponse.Succeeded)
                    {
                        List<string> users = userResponse.Data.Select(x => x.Id).ToList();
                        if (_hubConnection is not null)
                        {
                            await _hubConnection.SendAsync(EndPoints.Hub.SendUpdateAuthState, users);
                        }
                    }
                    _snackbar.Add(_messageResources[MessageResources.ClientSuccessfullyDeleted], Severity.Success);
                }
                else
                {
                    _snackbar.Add(_messageResources[MessageResources.DeletingClientFailed], Severity.Error);
                    foreach (var message in deleteResponse.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
                await _mudDataGrid.ReloadServerData();
            }
        }

        private async Task<GridData<TenantResponse>> ReloadDataAsync(GridState<TenantResponse> state)
        {
            IsBusy = true;
            var result = await _TenantDataService.GetTenantsPagedAsync(state.Page, state.PageSize, Query);
            if (result.Succeeded)
            {
                TenantPagedCollection = result.Data;
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
            var clients = new GridData<TenantResponse>
            {
                Items = TenantPagedCollection.Items,
                TotalItems = TenantPagedCollection.TotalCount
            };
            IsBusy = false;

            return clients;
        }

        public async void OnSearchData(string query)
        {
            Query = query;
            await _mudDataGrid?.ReloadServerData();
        }

    }
}