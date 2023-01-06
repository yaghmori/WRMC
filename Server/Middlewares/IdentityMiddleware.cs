using System.Security.Claims;
using AutoMapper;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Helpers;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;

namespace WRMC.Server.Middlewares
{
    public class IdentityMiddleware
    {
        private readonly RequestDelegate _next;
        public IdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IUnitOfWork unitOfWork,IMapper mapper)
        {
            if (context.User.Identity == null || !context.User.Identity.IsAuthenticated)
            {
                // user is not authenticated
                await _next(context);
                return;
            }
            var userId = context.User.FindFirst(x => x.Type.Equals(ApplicationClaimTypes.UserId))?.Value!;
            if (userId == null)
            {
                // not found
                await _next(context);
                return;
            }

            //RoleClaims
            var roles = await unitOfWork.UserRoles.GetAllAsync(predicate: x => x.UserId.ToString().Equals(userId),selector:s=>new Role
            {
                Id = s.Role.Id,
                Name = s.Role.Name,
            });
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ApplicationClaimTypes.Role, role.Name));
                var items = await unitOfWork.RoleClaims.GetAllAsync(predicate: x => x.RoleId==role.Id ,
                    selector:s=>new Claim(s.ClaimType,s.ClaimValue));
                    roleClaims.AddRange(items);
            }

            //userClaims
            var userClaims = new List<Claim>();
            var permissions = await unitOfWork.UserClaims.GetAllAsync(predicate: x => x.UserId.ToString().Equals(userId),
               selector: s => new Claim(s.ClaimType, s.ClaimValue));
                userClaims.AddRange(permissions);

            //Tenants
            var tenantClaims = new List<Claim>();
            var tenants = await unitOfWork.UserTenants.GetAllAsync(predicate: x => x.UserId.ToString().Equals(userId),
                 selector: s => new Claim(ApplicationClaimTypes.Tenant, s.TenantId.ToString()));
            tenantClaims.AddRange(tenants);
           

            var claims = new List<Claim>()
                .Union(roleClaims,new ClaimComparer())
                .Union(userClaims,new ClaimComparer())
                .Union(tenantClaims, new ClaimComparer());


            ClaimsIdentity identity = new ClaimsIdentity(claims);
            context.User.AddIdentity(identity);

            await _next(context);
        }

    }
}
