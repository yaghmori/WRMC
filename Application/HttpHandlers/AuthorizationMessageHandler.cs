using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.Helpers;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.Constants;

namespace WRMC.Core.Application.Handler
{

    public class HttpAuthorizationHandler : DelegatingHandler
    {
        //private readonly IRefreshTokenService _refreshTokenService;
        private readonly ILocalStorageService _localStorage;
        private readonly ISessionStorageService _sessionStorage;
        private readonly NavigationManager _navigation;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public HttpAuthorizationHandler(ILocalStorageService localStorageService, ISessionStorageService sessionStorage, NavigationManager navigation)
        {
            _localStorage = localStorageService;
            _sessionStorage = sessionStorage;
            _navigation = navigation;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var isPersistent = await _localStorage.GetItemAsync<bool>(AppConstants.IsPersistent);
            var jwt_token = string.Empty;
            var refresh_token = string.Empty;
            var tenantId = string.Empty;

            if (isPersistent)
            {
                jwt_token = await _localStorage.GetItemAsync<string>(AppConstants.AccessToken);
                refresh_token = await _localStorage.GetItemAsync<string>(AppConstants.RefreshToken);
                tenantId = await _localStorage.GetItemAsync<string>(AppConstants.TenantId);
            }
            else
            {
                jwt_token = await _sessionStorage.GetItemAsync<string>(AppConstants.AccessToken);
                refresh_token = await _sessionStorage.GetItemAsync<string>(AppConstants.RefreshToken);
                tenantId = await _sessionStorage.GetItemAsync<string>(AppConstants.TenantId);
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt_token);

            #region TenantHandler

            var absPath = request?.RequestUri?.AbsolutePath;
            if (tenantId != null && absPath.Contains(EndPoints.TenantEndPoint, StringComparison.InvariantCultureIgnoreCase))
            {
                request.Headers.Add(AppConstants.TenantId, tenantId);
            }

            #endregion

            #region TokenHandler

            if (!string.IsNullOrWhiteSpace(jwt_token))
            {
                var exp = JwtParser.GetClaimsFromJwt(jwt_token)?.FirstOrDefault(c => c.Type.Equals(AppClaimTypes.Expiration))?.Value;
                var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));
                var diff = expTime - DateTime.UtcNow;
                if (diff.TotalMinutes <= 1) //need to refresh token
                {
                    //  make sure the access token is only refreshed by one thread at a time. The other ones have to wait.
                    await _semaphore.WaitAsync();
                    try
                    {
                        var tokenRequest = new HttpRequestMessage
                        {
                            Method = HttpMethod.Post,
                            RequestUri = new Uri(AppConstants.ServerBaseAddress + EndPoints.AuthController.RefreshToken),
                            Content = new StringContent(JsonConvert.SerializeObject(new TokenRequest
                            {
                                Token = jwt_token,
                                RefreshToken = refresh_token
                            }), Encoding.UTF8, "application/json")
                        };
                        using (var refreshResponse = await base.SendAsync(tokenRequest, cancellationToken))
                        {
                            var tokenResponse = new TokenResponse();
                            var result = await refreshResponse.ToResult<TokenResponse>();
                            if (result?.Succeeded==true)
                            {

                                if (isPersistent)
                                    await _localStorage.SetItemAsync(AppConstants.AccessToken, result.Data.AccessToken);
                                else
                                    await _sessionStorage.SetItemAsync(AppConstants.AccessToken, result.Data.AccessToken);

                                await _localStorage.SetItemAsync(AppConstants.RefreshToken, result.Data.RefreshToken);
                                request.Headers.Remove("Authorization");
                                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", result.Data.AccessToken);

                            }
                            else
                            {
                                await _localStorage.ClearAsync();
                                await _sessionStorage.ClearAsync();
                                request.Headers.Remove("Authorization");
                            }
                        }
                    }
                    finally
                    {
                        //request complete so release
                        _semaphore.Release();
                    }

                }
            }

            #endregion

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }





    }
}
