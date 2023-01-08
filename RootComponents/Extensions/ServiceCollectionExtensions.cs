using Blazored.LocalStorage;
using Blazored.SessionStorage;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using System.Reflection;
using WRMC.Core.Application.Authorization;
using WRMC.Core.Application.DataServices;
using WRMC.Core.Application.Extensions;
using WRMC.Core.Application.Handler;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.MappingProfile;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.SignalR;
using WRMC.Core.Shared.Validators;
using WRMC.RootComponents.SignalRClient;
using WRMC.RootComponents.Validators;

namespace WRMC.RootComponents.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRootComponentService(this IServiceCollection services)
        {

            #region AutoMapper

            services.AddAutoMapper(typeof(MappingProfile));

            #endregion

            #region LocalStorage

            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();

            #endregion

            #region HttpClient

            services.AddTransient<HttpAuthorizationHandler>();
            services.AddHttpClient(ApplicationConstants.ServerHttpClientName, httpClient =>
            {
                httpClient.BaseAddress = new Uri(ApplicationConstants.ServerBaseAddress); ;
            }).AddHttpMessageHandler<HttpAuthorizationHandler>();




            #endregion

            #region DataServices
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

            #region Validators

            services.AddValidatorsFromAssemblyContaining<RegisterValidator>();//for ioc

            services.AddTransient<IUserValidator, UserRemoteValidator>();
            services.AddTransient<ITenantValidator, TenantRemoteValidator>();
            services.AddTransient<IRoleValidator, RoleRemoteValidator>();
            

            #endregion

            #region Authorization 
            services.AddScoped<AuthStateProvider>();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            services.AddScoped<IAuthorizationHandler, PermissionRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, TenantMemberRequirementHandler>();

            services.AddAuthorizationCore(options =>
            {
                options.InvokeHandlersAfterFailure = true;


                //PemissionPolicy
                var permissionList = typeof(ApplicationPermissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy));
                foreach (var permission in permissionList)
                {
                    var propertyValue = permission.GetValue(null);
                    options.InvokeHandlersAfterFailure = true;

                    if (propertyValue is not null)
                    {
                        options.AddPolicy(propertyValue.ToString(), policy => policy.RequireAuthenticatedUser()
                        .Requirements.Add(new PermissionRequirement(propertyValue.ToString())));
                    }
                }

            });
            services.AddAuthentication();

            #endregion

            #region SignalR

            services.AddScoped<IMainHubClient, MainSignalRClient>();
            services.AddScoped<IChatHubClient, ChatSignalRClient>();

            #endregion

            #region MudBlazor

            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                config.SnackbarConfiguration.BackgroundBlurred = true;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.ClearAfterNavigation = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 7000;
                config.SnackbarConfiguration.HideTransitionDuration = 300;
                config.SnackbarConfiguration.ShowTransitionDuration = 300;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            #endregion

            #region AppState

            services.AddSingleton<AppStateHandler>();

            #endregion

            return services;


        }
    }
}
