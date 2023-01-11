using Microsoft.AspNetCore.Authorization;

namespace WRMC.Core.Shared.AuthorizationHandler
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
        public string Permission { get; set; }
    }
}
