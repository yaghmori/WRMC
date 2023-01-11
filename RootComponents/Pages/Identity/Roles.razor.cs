using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Dialogs;
using WRMC.RootComponents.Shared;

namespace WRMC.RootComponents.Pages.Identity
{
    public partial class Roles
    {
        private IPagedList<RoleResponse> RolesPagedCollection = new PagedList<RoleResponse>();
        private MudDataGrid<RoleResponse>? _mudDataGrid = new();
        private string Query { get; set; } = string.Empty;



        protected override async Task OnInitializedAsync()
        {
            _appState.SetAppTitle(_viewLocalizer[ViewResources.Roles]);
        }
        private async Task AddOrRemoveUsers(RoleResponse role)
        {
            var parameters = new DialogParameters { { "RoleId", role.Id } };
            var options = new DialogOptions()
            { CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = _dialog.Show<RoleUsersDialog>(role.Name, parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {

                await _mudDataGrid.ReloadServerData();
            }
        }
        private async Task AddOrRemoveRoleClaims(RoleResponse role)
        {
            var parameters = new DialogParameters { { "RoleId", role.Id } };
            var options = new DialogOptions()
            { CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = _dialog.Show<RoleClaimsDialog>(role.Name, parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                //SignalR
                var usersResponse = await _roleDataService.GetRoleUsersAsync(role.Id);
                if (usersResponse.Succeeded)
                {
                }

                await _mudDataGrid.ReloadServerData();
            }
        }
        private async Task AddOrUpdateRole(RoleResponse item)
        {
            var parameters = new DialogParameters();
            var title = "";
            IReadOnlyList<string> users = new List<string>();

            if (item == null) //New
            {
                parameters.Add("RoleId", string.Empty);
                title = _viewLocalizer[ViewResources.AddNewRole];
            }
            else //Edit
            {
                parameters.Add("RoleId", item.Id);
                var usersResponse = await _roleDataService.GetRoleUsersAsync(item.Id);
                if (usersResponse.Succeeded)
                {
                    users = usersResponse.Data.Select(x => x.Id).ToList();
                }
                title = _viewLocalizer[ViewResources.UpdateRole];
            }

            var options = new DialogOptions()
            { CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = _dialog.Show<AddOrUpdateRoleDialog>(title, parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await _mudDataGrid.ReloadServerData();
            }
        }
        private async Task DeleteRole(RoleResponse role)
        {
            var parameters = new DialogParameters
            {
                { "Title", role.Name },
                { "ButtonText", _viewLocalizer[ViewResources.DeleteRole].Value },
                { "ContentText", _messageLocalizer[MessageResources.DoYouReallyWantToDeleteRole, role.Name].Value },
                { "ButtonColor", Color.Error },
                { "ButtonIcon", Icons.Rounded.Delete },
                { "TitleIcon", Icons.Rounded.Delete },
            };
            var options = new DialogOptions()
            {
                CloseButton = true,
                MaxWidth = MaxWidth.ExtraSmall
            };
            var dialog = _dialog.Show<MessageDialog>("", parameters, options);
            var dgResult = await dialog.Result;
            if (!dgResult.Cancelled)
            {
                //Get list of RoleUsers before delete role
                var usersResponse = await _roleDataService.GetRoleUsersAsync(role.Id);

                var result = await _roleDataService.DeleteRoleAsync(role.Id);
                if (result.Succeeded)
                {
                    _snackbar.Add(_messageLocalizer[MessageResources.RoleSuccessfullyDeleted], Severity.Success);
                    await _mudDataGrid.ReloadServerData();
                }
                else
                {
                    foreach (var message in result.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                        //_snackbar.Add(_messageLocalizer[MessageResources.DeletingRoleFailed"].Value, Severity.Error);

                    }
                }
            }
        }
        private async Task<GridData<RoleResponse>> ReloadDataAsync(GridState<RoleResponse> state)
        {
            IsBusy = true;
            var result = await _roleDataService.GetRolesPagedAsync(state.Page, state.PageSize, Query);
            if (result.Succeeded)
            {
                RolesPagedCollection = result.Data;
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }
            }
            var roles = new GridData<RoleResponse>
            {
                Items = RolesPagedCollection.Items,
                TotalItems = RolesPagedCollection.TotalCount
            };
            IsBusy = false;

            return roles;


        }
        private void OnSearchData(string query)
        {
            Query = query;
            _mudDataGrid.ReloadServerData();
        }
    }
}