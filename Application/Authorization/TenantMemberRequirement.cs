using Microsoft.AspNetCore.Authorization;

namespace WRMC.Core.Application.Authorization
{
    public class TenantMemberRequirement : IAuthorizationRequirement
    {
        public TenantMemberRequirement()
        {

        }
    }

}
