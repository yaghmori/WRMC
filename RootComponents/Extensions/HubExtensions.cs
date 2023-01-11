using Microsoft.AspNetCore.SignalR.Client;
using WRMC.Core.Shared.Constants;

namespace WRMC.RootComponents.Extensions
{
    public static class HubExtensions
    {
        public static HubConnection TryInitialize(this HubConnection hubConnection, string accessToken)
        {
            if (hubConnection == null)
            {
                hubConnection = new HubConnectionBuilder()
                                  .WithUrl(AppConstants.ServerBaseAddress + EndPoints.MainHub, options =>
                                  {
                                      options.AccessTokenProvider = async () => await Task.FromResult(accessToken);

                                  })
                                  .WithAutomaticReconnect()
                                  .Build();
            }
            return hubConnection;
        }
    }
}
