using Microsoft.AspNetCore.SignalR.Client;

namespace WRMC.Core.Shared.SignalR
{
    public interface ISignalRClient
    {
        HubConnectionState State { get; }
        HubConnection HubConnection { get; }
        bool IsConnected { get; }
        Task Start();
    }
}
