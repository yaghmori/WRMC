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

        public IPagedList<TenantResponse> TenantPagedCollection = new PagedList<TenantResponse>();

        private MudDataGrid<TenantResponse>? _mudDataGrid;
        private string Query { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            _appState.SetAppTitle(_viewResources[ViewResources.Tenants]);
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
            var parameters = new DialogParameters
            {
                { "Title", tenant.Name },
                { "ButtonText", _viewResources[ViewResources.Delete].Value },
                { "ContentText", _messageResources[MessageResources.DoYouReallyWantToDeleteClient].Value },
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
                    _snackbar.Add(_messageResources[MessageResources.ClientSuccessfullyDeleted].Value, Severity.Success);
                }
                else
                {
                    //_snackbar.Add(_messageResources[MessageResources.DeletingClientFailed].Value, Severity.Error);
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