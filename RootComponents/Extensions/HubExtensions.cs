using Microsoft.AspNetCore.SignalR.Client;
using WRMC.Core.Shared.Constant;

namespace WRMC.RootComponents.Extensions
{
    public static class HubExtensions
    {
        public static HubConnection TryInitialize(this HubConnection hubConnection, string accessToken)
        {
            if (hubConnection == null)
            {
                hubConnection = new HubConnectionBuilder()
                                  .WithUrl(ApplicationConstants.ServerBaseAddress + EndPoints.Hub.MainHubPath, options =>
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
