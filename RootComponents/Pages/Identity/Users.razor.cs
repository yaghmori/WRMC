using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Responses;
using WRMC.Infrastructure.Localization;
using WRMC.RootComponents.Dialogs;
using WRMC.RootComponents.Shared;

namespace WRMC.RootComponents.Pages.Identity
{
    public partial class Users
    {
        [Parameter] public EventCallback<bool> OnDrawerToggle { get; set; }
        [CascadingParameter] public HubConnection hubConnection { get; set; }

        private IPagedList<UserResponse> UserPagedCollection = new PagedList<UserResponse>();

        private MudDataGrid<UserResponse>? _mudDataGrid;

        private string Query { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }

        private async Task UpdateUserRoles(UserResponse user)
        {
            var parameters = new DialogParameters { { "UserId", user.Id } };
            var options = new DialogOptions()
            { CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = _dialog.Show<UserRolesDialog>(user.Email, parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var users = new List<string> { user.Id };
                if (hubConnection is not null)
                {
                    await hubConnection.SendAsync(EndPoints.Hub.SendUpdateAuthState, users);
                }
                await _mudDataGrid.ReloadServerData();
            }
        }

        private async Task UpdateUserClaims(UserResponse user)
        {
            var parameters = new DialogParameters { { "UserId", user.Id } };
            var options = new DialogOptions()
            { CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = _dialog.Show<UserClaimsDialog>(user.Email, parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var users = new List<string> { user.Id };
                if (hubConnection is not null)
                {
                    await hubConnection.SendAsync(EndPoints.Hub.SendUpdateAuthState, users);
                }
                await _mudDataGrid.ReloadServerData();
            }
        }

        private void ViewUserSession(UserResponse user)
        {
            _navigationManager.NavigateTo(ApplicationURL.ActiveSessions + "/" + user.Id);
        }

        private async Task UpdateUserTenants(UserResponse user)
        {
            var parameters = new DialogParameters { { "UserId", user.Id } };
            var options = new DialogOptions()
            { CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            var dialog = _dialog.Show<UserTenantsDialog>(user.Email, parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var users = new List<string> { user.Id };
                if (hubConnection is not null)
                {
                    await hubConnection.SendAsync(EndPoints.Hub.SendUpdateAuthState, users);
                }
                await _mudDataGrid.ReloadServerData();
            }
        }

        private async Task AddOrUpdateUser(UserResponse item)
        {
            var parameters = new DialogParameters();
            var title = "";
            var options = new DialogOptions()
            { CloseButton = true, DisableBackdropClick = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            IDialogReference? dialog;
            if (item != null)//Edit
            {
                parameters.Add("UserId", item.Id);
                title = _viewResources[ViewResources.UpdateUser];
                dialog = _dialog.Show<UpdateUserDialog>(title, parameters, options);
            }
            else
            {
                title = _viewResources[ViewResources.AddNewUser];
                dialog = _dialog.Show<CreateNewUserDialog>(title, parameters, options);
            }
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await _mudDataGrid.ReloadServerData();
            }

        }

        private async Task DeleteUser(UserResponse user)
        {
            var parameters = new DialogParameters
            {
                { "Title", user.Email },
                { "ButtonText", _viewResources[ViewResources.DeleteUser].Value },
                { "ContentText", _messageResources[MessageResources.DoYouReallyWantToDeleteUser, user.Email].Value },
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
                //SignalR
                var result = await _userDataService.DeleteUserAsync(user.Id);
                if (result?.Succeeded==true)
                {
                    var users = new List<string> { user.Id };
                    if (hubConnection is not null)
                    {
                        await hubConnection.SendAsync(EndPoints.Hub.SendUpdateAuthState, users);
                    }
                    _snackbar.Add(_messageResources[MessageResources.UserSuccessfullyDeleted].Value, Severity.Success);
                    await _mudDataGrid.ReloadServerData();
                }
                else
                {
                    foreach (var message in result?.Messages)
                    {
                        _snackbar.Add(message, Severity.Error);
                    }
                }
            }
        }

        private async Task<GridData<UserResponse>> ReloadDataAsync(GridState<UserResponse> state)
        {
            IsBusy = true;
            var result = await _userDataService.GetUsersPagedAsync(state.Page, state.PageSize, Query);
            if (result?.Succeeded==true)
            {
                UserPagedCollection = result.Data;

            }
            else
            {
                foreach (var message in result?.Messages)
                {
                    _snackbar.Add(message, Severity.Error);
                }

            }
            var users = new GridData<UserResponse>
            {
                Items = UserPagedCollection.Items,
                TotalItems = UserPagedCollection.TotalCount
            };
            IsBusy = false;
            return users;
        }

        private async void OnSearchData(string query)
        {
            Query = query;
            await _mudDataGrid.ReloadServerData();
        }

        protected async Task DrawerToggle(ChangeEventArgs e)
        {
            await OnDrawerToggle.InvokeAsync(true);
        }

        protected override async Task OnParametersSetAsync()
        {
            _appState.AppTitle = _viewResources[ViewResources.Users];
            await base.OnParametersSetAsync();
        }

    }
}