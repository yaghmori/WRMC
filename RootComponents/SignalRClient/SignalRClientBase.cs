using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.SignalR.Client;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.SignalR;

namespace WRMC.RootComponents.SignalR
{
    public abstract class SignalRClientBase : ISignalRClient, IAsyncDisposable
    {
        protected bool Started { get; private set; }

        protected SignalRClientBase(ISyncLocalStorageService localStorage, ISyncSessionStorageService sessionStorageService,string hubPath)
        {
            string accessToken;
            var isPersistent = localStorage.GetItem<bool>(ApplicationConstants.IsPersistent);
            if (isPersistent)
                accessToken = localStorage.GetItem<string>(ApplicationConstants.AccessToken);
            else
                accessToken = sessionStorageService.GetItem<string>(ApplicationConstants.AccessToken);
            if (accessToken == null)


                HubConnection = new HubConnectionBuilder()
                   .WithUrl(ApplicationConstants.ServerBaseAddress + hubPath , options =>
                   {
                       options.AccessTokenProvider = async () => await Task.FromResult(accessToken);
                   })
                   .WithAutomaticReconnect()
                   .Build();
        }


        public bool IsConnected =>
            HubConnection.State == HubConnectionState.Connected;

        public HubConnection HubConnection { get; set; }

        public async ValueTask DisposeAsync()
        {
            if (HubConnection != null)
            {
                await HubConnection.DisposeAsync();
            }
        }

        public async Task Start()
        {
            if (!Started)
            {
                await HubConnection.StartAsync();
                Started = true;
            }
        }

    }

}
