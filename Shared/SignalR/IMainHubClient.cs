namespace WRMC.Core.Shared.SignalR
{
    public interface IMainHubClient : ISignalRClient, IMainHub
    {
        void OnRegenerateToken(Action action);
        void OnUpdateAuthState(Action<List<string>> action);
        void OnUpdateUser(Action<List<string>> action);
        void OnUpdateCulture(Action<List<string>> action);
        void OnTerminateSession(Action<List<string>> action);
    }

}
