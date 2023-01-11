using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WRMC.Core.Shared.Constants;
using WRMC.RootComponents.Interfaces;

namespace WRMC.RootComponents.Shared
{
    public class BaseComponent : ComponentBase,IAuthBase
    {
        [CascadingParameter]
        public Task<AuthenticationState>? AuthState { get; set; }
        public bool IsBusy { get; set; } = false;
        public bool IsLoading { get; set; } = false;
        public bool IsSaving { get; set; } = false;
        public bool HasInit { get; set; } = false;
        public bool IsAuthenticated => CurrentUser?.Identity?.IsAuthenticated ?? false;
        public string CurrentUserId => CurrentUser?.FindFirst(x => x.Type == AppClaimTypes.UserId)?.Value ?? string.Empty;
        public string CurrentUserEmail => CurrentUser?.FindFirst(x => x.Type == AppClaimTypes.Email)?.Value ?? string.Empty;
        public ClaimsPrincipal? CurrentUser { get; set; }


        protected override async Task OnParametersSetAsync()
        {
            //CurrentUser= await ((AuthStateProvider)_authStateProvider).CurrentUser();
            //await ((AuthStateProvider)_authStateProvider).StateChangedAsync();
            var state = await AuthState!;
            CurrentUser = state.User;
            //StateHasChanged();

        }

    }
}
