namespace WRMC.Core.Shared.SignalR
{
    public interface ISignalRClient
    {
        bool IsConnected { get; }
        Task Start();
    }
}
