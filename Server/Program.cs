using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Server.Services.TokenService;
using Swashbuckle.AspNetCore.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using WRMC.Core.Shared.AuthorizationHandler;
using WRMC.Core.Shared.Constants;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.Helpers;
using WRMC.Core.Shared.MappingProfile;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Core.Shared.Validators;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Extensions;
using WRMC.Server.Hubs;
using WRMC.Server.Middlewares;
using WRMC.Server.Services;
using WRMC.Server.Validators;

var builder = WebApplication.CreateBuilder(args);

#region Controller && JsonSerializer
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        List<string> errors = actionContext.ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToList();
        var responseModel = Result<string>.Fail(errors);

        return new BadRequestObjectResult(responseModel);
    };
}).AddJsonOptions(options =>
{

}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Error;
});

#endregion

#region Validators

builder.Services.AddControllersWithViews()
        .AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssemblyContaining<CaseRequestValidator>();
            fv.ImplicitlyValidateChildProperties = true;
        });

builder.Services.AddScoped<IUserValidator, UserRemoteValidator>();
builder.Services.AddScoped<IRoleValidator, RoleRemoteValidator>();

#endregion

#region SignalR

builder.Services.AddSignalR();
builder.Services.AddSingleton<IUserIdProvider, UserIdProvider>();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});
//builder.Services.AddScoped<IMainHub,MainHub>();
builder.Services.AddScoped<MainHub>();
//builder.Services.AddHostedService<ReportInfoHostedService>();

#endregion

#region DbContext

var connectionString = builder.Environment.IsDevelopment() ? builder.Configuration.GetConnectionString("Development_db") : builder.Configuration.GetConnectionString("Production_db");
builder.Services.AddDbContext<ServerDbContext>(options => options.UseSqlServer(connectionString).EnableDetailedErrors(builder.Environment.IsDevelopment()), ServiceLifetime.Scoped);

#endregion

#region Identity

builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 1;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_@.";
    // lockout setup
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = false;
    options.Lockout.MaxFailedAccessAttempts = 5;

}).AddEntityFrameworkStores<ServerDbContext>().AddDefaultTokenProviders();

#endregion

#region UnitOfWork

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

#region CoreServices

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<ISmtpService, SmtpService>();
builder.Services.AddScoped<IMemoryCache, MemoryCache>();
builder.Services.AddScoped<ITokenService, TokenService>();

#endregion

#region Authentication && JWT

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer((Action<JwtBearerOptions>)(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = ConfigHelper.ValidationParameters;
    options.Events = new JwtBearerEvents
    {

      
        OnTokenValidated = async context =>
        {
            var unitOfWork = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();

            var accessToken = context.SecurityToken as JwtSecurityToken;
            if (accessToken != null)
            {
                var userId = context?.Principal?.GetUserId();
                var session = await unitOfWork.UserSessions.GetFirstOrDefaultAsync(predicate: x => x.AccessToken == accessToken.RawData && x.UserId.ToString().Equals(userId));
                
                if (session == null) // return unauthorized if token is not found on user sessions
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Response.ContentType = "application/json";
                    var result = JsonConvert.SerializeObject(Result.Fail("Token in not valid."));
                    await context.Response.WriteAsync(result);
                }
                else
                {
                    IEnumerable<Claim> claims = await ExtractClaims(userId, unitOfWork);
                    ClaimsIdentity identity = new ClaimsIdentity(claims);
                    context?.Principal?.AddIdentity(identity);
                }
            }
        },
        OnAuthenticationFailed = context =>
        {
            if (context.Exception is SecurityTokenExpiredException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(Result.Fail("The Token is expired."));
                return context.Response.WriteAsync(result);
            }
            else
            {

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(Result.Fail(messages: context.Exception.GetMessages().ToList()));
                return context.Response.WriteAsync(result);

            }
        },
        OnChallenge = context =>
        {
            context.HandleResponse();
            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(Result.Fail("Not Authorized."));
                return context.Response.WriteAsync(result);
            }
            return Task.CompletedTask;
        },
        OnForbidden = context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            context.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(Result.Fail("Not authorized to access this resource."));
            return context.Response.WriteAsync(result);
        },
    };

}));

#endregion

#region Authorization

builder.Services.AddScoped<IAuthorizationHandler, PermissionRequirementHandler>();
builder.Services.AddAuthorizationCore(options =>
{
    var permissionList = typeof(AppPermissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy));
    foreach (var permission in permissionList)
    {
        var propertyValue = permission.GetValue(null);

        if (propertyValue is not null)
        {
            options.AddPolicy(propertyValue.ToString(), policy => policy.Requirements.Add(new PermissionRequirement(propertyValue.ToString())));
        }
    }
});

#endregion

#region Cors
builder.Services.AddCors(options => options.AddPolicy(name: "Origins", policy =>
{
    policy.SetIsOriginAllowed(origin => new Uri(origin).Host.Equals("www.register.freepregtest.com")).AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddCors(options => options.AddPolicy(name: "Development", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

#endregion

#region Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Server.Api",
        Version = "v1",
        Description = "An API to perform server operations",
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {

        Description = "Please insert your JWT Token into field",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        BearerFormat = "JWT"

    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();


    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

#endregion

var app = builder.Build();
app.UseResponseCompression();
app.UseExceptionHandler("/Error");

if (app.Environment.IsDevelopment())
{
    app.UseCors("Development");

    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DisplayRequestDuration();
    });
}
else
{
    app.UseCors("Origins");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<MainHub>(EndPoints.MainHub);
app.MapHub<ChatHub>(EndPoints.ChatHub);

app.Run();

static async Task<IEnumerable<Claim>> ExtractClaims(string? userId, IUnitOfWork unitOfWork)
{
    //RoleClaims
    var roles = await unitOfWork.UserRoles.GetAllAsync(predicate: x => x.UserId.ToString().Equals(userId), selector: s => new Role
    {
        Id = s.Role.Id,
        Name = s.Role.Name,
    });
    var roleClaims = new List<Claim>();
    foreach (var role in roles)
    {
        roleClaims.Add(new Claim(AppClaimTypes.Role, role.Name));
        var items = await unitOfWork.RoleClaims.GetAllAsync(predicate: x => x.RoleId == role.Id,
            selector: s => new Claim(s.ClaimType, s.ClaimValue));
        roleClaims.AddRange(items);
    }

    //userClaims
    var userClaims = new List<Claim>();
    var permissions = await unitOfWork.UserClaims.GetAllAsync(predicate: x => x.UserId.ToString().Equals(userId),
       selector: s => new Claim(s.ClaimType, s.ClaimValue));
    userClaims.AddRange(permissions);



    var claims = new List<Claim>()
        .Union(roleClaims, new ClaimComparer())
        .Union(userClaims, new ClaimComparer());

    return claims;
}