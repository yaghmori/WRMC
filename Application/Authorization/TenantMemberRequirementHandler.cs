using Microsoft.AspNetCore.Authorization;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Responses;

namespace WRMC.Core.Application.Authorization
{

    public class TenantMemberRequirementHandler : AuthorizationHandler<TenantMemberRequirement, TenantResponse>
    {
        public TenantMemberRequirementHandler()
        {

        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, TenantMemberRequirement requirement, TenantResponse tenant)
        {
            if (context?.User == null)
            {
                await Task.CompletedTask;
                return;
            }
            if (tenant == null)
            {
                await Task.CompletedTask;
                return;
            }

            if (tenant.ExpireDate <= DateTime.UtcNow)
            {
                await Task.CompletedTask;
                return;
            }

            if (context.User.Claims.Any(c => c.Type.Equals(ApplicationClaimTypes.Tenant) && c.Value.Equals(tenant.Id)))
                context?.Succeed(requirement);
            await Task.CompletedTask;
            return;
        }
    }

}
