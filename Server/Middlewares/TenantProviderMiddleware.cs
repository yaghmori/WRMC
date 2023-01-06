using Microsoft.EntityFrameworkCore;
using WRMC.Core.Shared.Constant;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.UnitOfWork;

namespace WRMC.Server.Middlewares
{
    public class TenantProviderMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantProviderMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {


            var tenantId = context.Request.Headers[ApplicationConstants.TenantId];

            if (!string.IsNullOrWhiteSpace(tenantId))
            {
                var tenant =await unitOfWork.Tenants.FindAsync(Guid.Parse(tenantId));
                if(tenant is not null)
                {
                    unitOfWork.TenantDbContext.Database.SetConnectionString(tenant.ConnectionString);
                    //TODO : Set Connection String 
                    //TenantDbContext.ConnectionString = tenant.ConnectionString;
                }
            }
            await _next.Invoke(context);
        }

    }
}
