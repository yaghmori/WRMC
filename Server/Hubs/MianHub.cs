using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using WRMC.Core.Shared.SignalR;

namespace WRMC.Server.Hubs
{
    [Authorize]
    public class MainHub : Hub<IMainHub>
    {


        /// <summary>
        /// Regenerate Access Token
        /// </summary>
        /// <returns></returns>
        public async Task RegenerateTokens()
        {
            await Clients.All.RegenerateTokens();
        }

        /// <summary>
        /// update Authenticate state Provider
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public async Task UpdateAuthState(List<string> userIds)
        {
            if (userIds == null || !userIds.Any())
                await Clients.All.UpdateAuthState(userIds);
            else
                await Clients.Users(userIds.Select(x => x.ToLowerInvariant())).UpdateAuthState(userIds);
        }

        /// <summary>
        /// Update Current User
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public async Task UpdateUser(List<string> userIds)
        {
            if (userIds == null || !userIds.Any())
                await Clients.All.UpdateUser(userIds);
            else
                await Clients.Users(userIds.Select(x => x.ToLowerInvariant())).UpdateUser(userIds);
        }
        /// <summary>
        /// Update currentUser Culture
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public async Task UpdateCulture(List<string> userIds)
        {
            if (userIds == null || !userIds.Any())
                await Clients.All.UpdateCulture(userIds);
            else
                await Clients.Users(userIds.Select(x => x.ToLowerInvariant())).UpdateCulture(userIds);
        }

        /// <summary>
        /// Terminate User Sessions
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public async Task TerminateSession(List<string> userIds)
        {
            if (userIds == null || !userIds.Any())
                await Clients.All.TerminateSession(userIds);
            else
                await Clients.Users(userIds.Select(x => x.ToLowerInvariant())).TerminateSession(userIds);
        }


    }
}


