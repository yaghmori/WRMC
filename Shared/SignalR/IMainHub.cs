namespace WRMC.Core.Shared.SignalR
{
    public interface IMainHub
    {
        Task RegenerateTokens();
        Task UpdateAuthState(List<string> userIds);
        Task UpdateUser(List<string> userIds);
        Task UpdateCulture(List<string> userIds);
        Task TerminateSession(List<string> userIds);
    }


}
