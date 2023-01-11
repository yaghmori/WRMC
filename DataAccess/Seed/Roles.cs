using WRMC.Core.Shared.Constants;
using WRMC.Infrastructure.Domain.Entities;

namespace WRMC.Infrastructure.DataAccess.Context
{
    static partial class Seed
    {

        public static List<Role> Roles = new List<Role> {
            new Role { Id=Guid.NewGuid(), Name = AppRoles.Administrator, NormalizedName = AppRoles.Administrator.Normalize().ToUpper() },
            new Role { Id=Guid.NewGuid(), Name = AppRoles.Client, NormalizedName = AppRoles.Client.Normalize().ToUpper() },
        };
    }
}

