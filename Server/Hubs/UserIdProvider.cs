using Microsoft.AspNetCore.SignalR;
using WRMC.Core.Shared.Extensions;

namespace WRMC.Server.Hubs
{
    /// <inheritdoc />
    public class UserIdProvider : IUserIdProvider
    {
        /// <summary>
        /// Get Current User from HttpContextAccessor
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.User?.GetUserId()?.ToLower()!;
        }
    }

}
