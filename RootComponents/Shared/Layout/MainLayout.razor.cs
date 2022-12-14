using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.JsonPatch;
using MudBlazor;
using System.Security.Claims;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;

namespace WRMC.RootComponents.Shared.Layout
{
    public partial class MainLayout 
    {

        [CascadingParameter] public Task<AuthenticationState>? AuthState { get; set; }
        public bool IsLoading { get; set; } = false;
        public bool IsDrawerOpen { get; set; } = true;
        public ClaimsPrincipal? CurrentUser { get; set; }
        private UserResponse User { get; set; } = new();
        public string ModeIcon => User.UserSetting.DarkMode ? Icons.Outlined.LightMode : Icons.Outlined.DarkMode;
        public string RTLIcon => User.UserSetting.RightToLeft ? Icons.Filled.FormatTextdirectionLToR : Icons.Filled.FormatTextdirectionRToL;


        public List<BreadcrumbItem> BreadcrumbItems = new();

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthState!;
            var user = authState.User;

            if (user?.Identity?.IsAuthenticated != true)
            {
                return;
            }
            await UpdateCurrentUserAsync();
            HubSubscriptions();
            await _mainSignalRClinet.Start();

        }

        private void HubSubscriptions()
        {
            _mainSignalRClinet.OnRegenerateToken (async () =>
            {
                await _authStateProvider.GetAuthenticationStateAsync();
                await UpdateCurrentUserAsync();
                StateHasChanged();
            });

            _mainSignalRClinet.OnUpdateCulture(async (List<string> userIds) =>
            {
                _navigationManager.NavigateTo(_navigationManager.Uri, forceLoad: true);
            });

            _mainSignalRClinet.OnUpdateUser(async (List<string> userIds) =>
            {
                await UpdateCurrentUserAsync();
                StateHasChanged();
            });

            _mainSignalRClinet.OnTerminateSession(async (List<string> userIds) =>
            {
                _navigationManager.NavigateTo(AppURL.Logout);
            });


        }

        private async Task UpdateCurrentUserAsync()
        {
            var state = await AuthState!;
            CurrentUser = state.User;

            var userId = state.User.GetUserId();
            var result = await _userDataService.GetUserAsync(userId);
            if (result.Succeeded)
            {
                User = result.Data;
                StateHasChanged();
            }
        }

        private void DrawerToggle()
        {
            IsDrawerOpen = !IsDrawerOpen;
        }

        private async void DarkModeToggle()
        {
            User.UserSetting.DarkMode = !User.UserSetting.DarkMode;

            var patchDoc = new JsonPatchDocument<UserSettingRequest>();
            patchDoc.Replace(e => e.DarkMode, User.UserSetting.DarkMode);
            var result = await _userSettingDataService.UpdateSettingsAsync(User.UserSetting.Id, patchDoc);
            if(result?.Succeeded==true)
            {
                ////SignalR
                //var users = new List<string> { User.Id };
                //await _mainSignalRClinet.UpdateUser(users);
            }

        }

        private async void RtlToggle()
        {
            User.UserSetting.RightToLeft = !User.UserSetting.RightToLeft;
            var patchDoc = new JsonPatchDocument<UserSettingRequest>();
            patchDoc.Replace(e => e.RightToLeft, User.UserSetting.RightToLeft);
            var result = await _userSettingDataService.UpdateSettingsAsync(User.UserSetting.Id, patchDoc);
            //  await OnUserUpdated.InvokeAsync(User);
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            var relativePath = _navigationManager.ToBaseRelativePath(_navigationManager.Uri);
            BreadcrumbItems.Clear();
            var list = relativePath.Split('/');
            foreach (var item in list)
            {
                BreadcrumbItems.Add(new BreadcrumbItem(item, href: item));
            }

            StateHasChanged();
        }


    }
}