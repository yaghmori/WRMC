using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using WRMC.Core.Shared.SignalR;

namespace WRMC.Server.Hubs
{
    [Authorize]
    public class ChatHub : Hub<IChatHub>
    {

        /// <summary>
        /// Send Message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        /// <param name="userIds"></param>
        public async Task SendMessage(string sender ,string message ,List<string> userIds)
        {
            await Clients.All.SendMessage(sender, message, userIds);
            if (userIds == null || !userIds.Any())
                await Clients.All.SendMessage(sender, message, userIds);
            else
                await Clients.Users(userIds.Select(x => x.ToLowerInvariant())).SendMessage(sender, message, userIds);
        }


    }
}


