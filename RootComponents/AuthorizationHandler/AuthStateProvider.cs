using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WRMC.Core.Application.DataServices;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Helpers;
using WRMC.Core.Shared.Responses;

namespace WRMC.RootComponents
{


    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly ISessionStorageService _sessionStorage;

        private readonly IUserDataService _userDataService;
        private readonly IRoleDataService _roleDataService;
        private readonly AuthenticationState _anonymous;

        public AuthStateProvider(ILocalStorageService localStorageService, IUserDataService userDataService, ISessionStorageService sessionStorage, IRoleDataService roleDataService)
        {
            _localStorage = localStorageService;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            _userDataService = userDataService;
            _sessionStorage = sessionStorage;
            _roleDataService = roleDataService;
        }
        
        public async Task StateChangedAsync()
        {
            var authState = Task.FromResult(await GetAuthenticationStateAsync());
            NotifyAuthenticationStateChanged(authState);

        }

        public async Task<ClaimsPrincipal> CurrentUser()
        {
            var authState = Task.FromResult(await GetAuthenticationStateAsync());
            NotifyAuthenticationStateChanged(authState);
            return authState.Result.User;
        }

        public async Task NotifyLoginAsync(TokenResponse token, bool isPersistent)
        {
            await ClearLocalStorage();

            await _localStorage.SetItemAsync(AppConstants.IsPersistent, isPersistent);

            if (isPersistent)
            {
                await _localStorage.SetItemAsync(AppConstants.AccessToken, token.AccessToken);
                await _localStorage.SetItemAsync(AppConstants.RefreshToken, token.RefreshToken);
            }
            else
            {
                await _sessionStorage.SetItemAsync(AppConstants.AccessToken, token.AccessToken);
                await _sessionStorage.SetItemAsync(AppConstants.RefreshToken, token.RefreshToken);
            }
            var authenticatedUser = new ClaimsPrincipal(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.GetClaimsFromJwt(token.AccessToken), "jwtAuthType")));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }
        
        public async Task NotifyLogoutAsync()
        {
            await ClearLocalStorage();
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }

        private async Task ClearLocalStorage()
        {
            await _localStorage.ClearAsync();
            await _sessionStorage.ClearAsync();
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string savedToken;

            var isPersistent = await _localStorage.GetItemAsync<bool>(AppConstants.IsPersistent);
            if (isPersistent)
                savedToken = await _localStorage.GetItemAsync<string>(AppConstants.AccessToken);
            else
                savedToken = await _sessionStorage.GetItemAsync<string>(AppConstants.AccessToken);

            if (string.IsNullOrWhiteSpace(savedToken))
            {
                await ClearLocalStorage();
                return _anonymous;
            }

            //TODO : Validate JWT
            //TODO : Check user session
            //TODO : Optimize api calls

            //GetJWTClaims
            var jwtClaims = JwtParser.GetClaimsFromJwt(savedToken).ToList();
            var userId = jwtClaims.FirstOrDefault(x => x.Type.Equals(AppClaimTypes.UserId))?.Value!;
            if (string.IsNullOrWhiteSpace(userId))
            {
                await ClearLocalStorage();
                return _anonymous;
            }


            //GetUserClaims
            var userClaims = new List<Claim>();
            var permissionResponse = await _userDataService.GetUserClaimsAsync(userId);
            if (permissionResponse.Succeeded)
                userClaims = permissionResponse.Data.Select(s => new Claim(s.ClaimType, s.ClaimValue)).ToList();

            //GetRoleClaims
            var roleClaims = new List<Claim>();
            var roleResponse = await _userDataService.GetUserRolesAsync(userId);
            if (roleResponse.Succeeded)
            {
                foreach (var role in roleResponse.Data)
                {
                    roleClaims.Add(new Claim(AppClaimTypes.Role, role.Name));
                    var roleClaimsResponse = await _roleDataService.GetRoleClaimsAsync(role.Id);
                    if (roleClaimsResponse.Succeeded)
                    {
                        roleClaims.AddRange(roleClaimsResponse.Data.Select(s => new Claim(s.ClaimType, s.ClaimValue)).ToList());
                    }
                }
            }




            var claims = new List<Claim>()
                .Union(jwtClaims, new ClaimComparer())
                .Union(roleClaims, new ClaimComparer())
                .Union(userClaims, new ClaimComparer());

            

            var claimIdentity = new ClaimsIdentity(claims, "jwt");
            var state = new AuthenticationState(new ClaimsPrincipal(claimIdentity));
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;

        }

    }

}
