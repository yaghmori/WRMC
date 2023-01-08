using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using WRMC.Core.Shared.SignalR;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;

namespace WRMC.Server.Hubs
{
    [Authorize]
    public class MainHub : Hub<IMainHub>
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task RegenerateTokens(List<string> userIds)
        {
            if (userIds == null || !userIds.Any())
                await Clients.All.RegenerateTokens();
            else
                await Clients.Users(userIds).RegenerateTokens();
        }

        public async Task UpdateAuthState(List<string> userIds)
        {
            if (userIds == null || !userIds.Any())
                await Clients.All.UpdateAuthState(userIds);
            else
                await Clients.Users(userIds).UpdateAuthState(userIds);
        }

        public async Task UpdateUser(List<string> userIds)
        {
            if (userIds == null || !userIds.Any())
                await Clients.All.UpdateUser(userIds);
            else
                await Clients.Users(userIds).UpdateUser(userIds);
        }

        public async Task UpdateCulture(List<string> userIds)
        {
            if (userIds == null || !userIds.Any())
                await Clients.All.UpdateCulture(userIds);
            else
                await Clients.Users(userIds.Select(x => x.ToLowerInvariant())).UpdateCulture(userIds);
        }

        public async Task TerminateSession(List<string> userIds)
        {
            if (userIds == null || !userIds.Any())
                await Clients.All.TerminateSession(userIds);
            else
                await Clients.Users(userIds.Select(x => x.ToLowerInvariant())).TerminateSession(userIds);
        }

        public override async Task OnConnectedAsync()
        {
            var id = Context.UserIdentifier;
            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(Context.UserIdentifier));
            if(user != null)
            {
                user.IsOnline = true;
            }
            _unitOfWork.Users.Update(user);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var user = await _unitOfWork.Users.GetFirstOrDefaultAsync(predicate: x => x.Id.ToString().Equals(Context.UserIdentifier));
            if (user != null)
            {
                user.IsOnline = false;
            }
            _unitOfWork.Users.Update(user);
            await _unitOfWork.ServerDbContext.SaveChangesAsync();
        }

    }
}


