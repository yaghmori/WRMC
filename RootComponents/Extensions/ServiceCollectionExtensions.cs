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
using WRMC.Core.Application.Extensions;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.MappingProfile;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.SignalR;
using WRMC.RootComponents.SignalRClient;

namespace WRMC.RootComponents.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRootComponentService(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();

            services.AddSingleton<AppStateHandler>();
            services.AddScoped<AuthStateProvider>();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            //services.AddTransient<IValidator<DemographicIntakeRequest>, DemographicIntakeRequestValidator>();

            services.AddScoped<IAuthorizationHandler, PermissionRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, TenantMemberRequirementHandler>();
            services.AddValidatorsFromAssemblyContaining<DemographicIntakeValidator>();

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
            services.AddApplicationService();
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

            // SignalR Clients
            services.AddScoped<IMainHubClient, MainSignalRClient>();
            services.AddScoped<IChatHubClient, ChatSignalRClient>();

            return services;


        }
    }
}
