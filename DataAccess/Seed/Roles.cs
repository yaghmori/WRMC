using WRMC.Core.Shared.Constant;
using WRMC.Infrastructure.Domain.Entities;

namespace WRMC.Infrastructure.DataAccess.Context
{
    static partial class Seed
    {

        public static List<Role> Roles = new List<Role> {
            new Role { Id=Guid.NewGuid(), Name = ApplicationRoles.Administrator, NormalizedName = ApplicationRoles.Administrator.Normalize().ToUpper() },
            new Role { Id=Guid.NewGuid(), Name = ApplicationRoles.Client, NormalizedName = ApplicationRoles.Client.Normalize().ToUpper() },
        };
    }
}

