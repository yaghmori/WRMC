using Microsoft.AspNetCore.SignalR;
using WRMC.Core.Application.Extensions;
using WRMC.Core.Shared.Constant;

namespace WRMC.Server.Hubs
{
    /// <inheritdoc />
    public class HubUserIdProvider : IUserIdProvider
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
