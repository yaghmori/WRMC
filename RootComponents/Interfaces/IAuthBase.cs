using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace WRMC.RootComponents.Interfaces
{
    public interface IAuthBase
    {
        Task<AuthenticationState>? AuthState { get; set; }
        ClaimsPrincipal? CurrentUser { get; set; }
        string CurrentUserEmail { get; }
        string CurrentUserId { get; }
        bool IsAuthenticated { get; }

    }
}