using Microsoft.AspNetCore.Authorization;
using WRMC.Core.Shared.Constant;

namespace WRMC.Core.Application.Authorization
{

    public class PermissionRequirementHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context?.User == null)
            {
                await Task.CompletedTask;
                return;
            }
          
            if (context.User.Claims.Any(c => c.Type == ApplicationClaimTypes.Permission && c.Value == requirement.Permission))
                context?.Succeed(requirement);
            await Task.CompletedTask;
            return;
        }
    }

}
