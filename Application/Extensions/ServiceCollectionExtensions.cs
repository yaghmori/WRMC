using Microsoft.Extensions.DependencyInjection;
using WRMC.Core.Application.DataServices;
using WRMC.Core.Application.Handler;
using WRMC.Core.Shared.Constant;

namespace WRMC.Core.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddHttpClient(ApplicationConstants.ServerHttpClientName, httpClient =>
            {
                httpClient.BaseAddress = new Uri(ApplicationConstants.ServerBaseAddress); ;
            }).AddHttpMessageHandler<AuthorizationMessageHandler>();
            services.AddTransient<AuthorizationMessageHandler>();

            #region DataService
            services.AddScoped<IAuthDataService, AuthDataService>();
            services.AddScoped<ICultureDataService, CultureDataService>();
            services.AddScoped<IUserDataService, UserDataService>();
            services.AddScoped<IRoleDataService, RoleDataService>();
            services.AddScoped<ITenantDataService, TenantDataService>();
            services.AddScoped<IAppSettingDataService, AppSettingDataService>();
            services.AddScoped<IUserSettingDataService, UserSettingDataService>();
            services.AddScoped<ICaseDataService, CaseDataService>();
            services.AddScoped<IVisitDataService, VisitDataService>();
            services.AddScoped<ISectionDataService, SectionDataService>();
            services.AddScoped<IIntroMethodDataService, IntroMethodDataService>();
            services.AddScoped<IRegionDataService, RegionDataService>();
            services.AddScoped<IDemographicIntakesDataService, DemographicIntakesDataService>();
            services.AddScoped<IMedicalIntakesDataService, MedicalIntakesDataService>();
            #endregion

            return services;
        }

    }
}
