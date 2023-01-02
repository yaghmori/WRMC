using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.SignalR.Client;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.SignalR;
using WRMC.RootComponents.SignalR;

namespace WRMC.RootComponents.SignalRClient
{
    public class ChatSignalRClient : SignalRClientBase, IChatHubClient
    {
        public ChatSignalRClient(ISyncLocalStorageService localStorage, ISyncSessionStorageService sessionStorageService)
            : base(localStorage, sessionStorageService, EndPoints.Hub.MainHubPath)
        {
        }



        //ChatHubClient
        public void OnMessageReceived(Action<string, string, List<string>> action)
        {
            if (!Started)
            {
                HubConnection.On(nameof(OnMessageReceived), action);
            }
        }



        
       
        //MainHub

        public async Task SendMessage(string sender, string message, List<string> userIds)
        {
            await HubConnection.SendAsync(nameof(SendMessage));
        }
    }
}
