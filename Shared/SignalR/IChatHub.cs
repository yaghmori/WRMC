namespace WRMC.Core.Shared.SignalR
{
    public interface IChatHub
    {
        Task SendMessage(string sender, string message, List<string> userIds);
    }


}
