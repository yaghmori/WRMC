using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.SignalR.Client;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.SignalR;
using WRMC.RootComponents.SignalR;

namespace WRMC.RootComponents.SignalRClient
{
    public class MainSignalRClient : SignalRClientBase, IMainHubClient
    {
        public MainSignalRClient(ISyncLocalStorageService localStorage, ISyncSessionStorageService sessionStorageService)
            : base(localStorage, sessionStorageService, EndPoints.Hub.MainHubPath)
        {
        }


        //MainHubClient
        public void OnRegenerateToken(Action action)
        {
            if (!Started)
            {
                HubConnection.On(nameof(OnRegenerateToken), action);
            }
        }
        public void OnRegenerateToken(Action<List<string>> action)
        {
            if (!Started)
            {
                HubConnection.On(nameof(OnRegenerateToken), action);
            }
        }
        public void OnTerminateSession(Action<List<string>> action)
        {
            if (!Started)
            {
                HubConnection.On(nameof(OnTerminateSession), action);
            }
        }
        public void OnUpdateAuthState(Action<List<string>> action)
        {
            if (!Started)
            {
                HubConnection.On(nameof(OnUpdateAuthState), action);
            }
        }
        public void OnUpdateCulture(Action<List<string>> action)
        {
            if (!Started)
            {
                HubConnection.On(nameof(OnUpdateCulture), action);
            }
        }
        public void OnUpdateUser(Action<List<string>> action)
        {
            if (!Started)
            {
                HubConnection.On(nameof(OnUpdateUser), action);
            }
        }

        //MainHub
        public async Task RegenerateTokens()
        {
            await HubConnection.SendAsync(nameof(RegenerateTokens));
        }
        public async Task TerminateSession(List<string> userIds)
        {
            await HubConnection.SendAsync(nameof(TerminateSession), userIds);
        }
        public async Task UpdateAuthState(List<string> userIds)
        {
            await HubConnection.SendAsync(nameof(UpdateAuthState), userIds);
        }
        public async Task UpdateCulture(List<string> userIds)
        {
            await HubConnection.SendAsync(nameof(UpdateCulture), userIds);
        }
        public async Task UpdateUser(List<string> userIds)
        {
            await HubConnection.SendAsync(nameof(UpdateUser), userIds);
        }

    }
}
