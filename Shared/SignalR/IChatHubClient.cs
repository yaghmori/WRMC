namespace WRMC.Core.Shared.SignalR
{
    public interface IChatHubClient : ISignalRClient, IChatHub
    {
        void OnMessageReceived(Action<string, string, List<string>> action);
    }

}
