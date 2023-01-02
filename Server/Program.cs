using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
using System.Net;
using System.Reflection;
using WRMC.Core.Application.Authorization;
using WRMC.Core.Shared.Constant;
using WRMC.Core.Shared.Helpers;
using WRMC.Core.Shared.MappingProfile;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Core.Shared.SignalR;
using WRMC.Infrastructure.DataAccess.Context;
using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.UnitOfWork;
using WRMC.Server.Hubs;
using WRMC.Server.Middlewares;
using WRMC.Server.Services;

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

#region FluentValidation
builder.Services.AddControllersWithViews()
        .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CaseRequestValidator>());

#endregion

#region SignalR

builder.Services.AddSignalR();
builder.Services.AddSingleton<IUserIdProvider, HubUserIdProvider>();
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
builder.Services.AddDbContext<ServerDbContext>(options => options.UseSqlServer(connectionString)
    , ServiceLifetime.Scoped);

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

builder.Services.AddScoped<IUnitOfWork<ServerDbContext>, UnitOfWork<ServerDbContext>>();

#endregion

#region CoreServices

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddSingleton<ISmtpService, SmtpService>();
builder.Services.AddScoped<IMemoryCache, MemoryCache>();
builder.Services.AddScoped<ITokenService, TokenService>();

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = ConfigHelper.ValidationParameters;
    options.Events = new JwtBearerEvents
    {
        OnTokenValidated = async context =>
        {
            var unitOfWork = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork<ServerDbContext>>();
            var userId = context.Principal?.FindFirst(x => x.Type.Equals(ApplicationClaimTypes.UserId))?.Value!;
            var user = await unitOfWork.Users.FindAsync(Guid.Parse(userId));
            if (user == null)
            {
                // return unauthorized if user no longer exists
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(Result.Fail("User no longer exists."));
                await context.Response.WriteAsync(result);
            }
        },
        OnAuthenticationFailed = c =>
        {
            if (c.Exception is SecurityTokenExpiredException)
            {
                c.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                c.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(Result.Fail("The Token is expired."));
                return c.Response.WriteAsync(result);
            }
            else
            {

                c.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                c.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(Result.Fail("An unhandled error has occurred." + "r\n" + c.Exception.ToString()));
                return c.Response.WriteAsync(result);

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

});

#endregion

#region Authorization

builder.Services.AddScoped<IAuthorizationHandler, PermissionRequirementHandler>();
builder.Services.AddAuthorizationCore(options =>
{
    var permissionList = typeof(ApplicationPermissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy));
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
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseMiddleware<IdentityMiddleware>();

app.UseWhen(context => context.Request.Path.StartsWithSegments(EndPoints.TenantEndPoint), appBuilder =>
{
    app.UseMiddleware<TenantProviderMiddleware>();
});

app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.MapHub<MainHub>(EndPoints.Hub.MainHubPath);
app.MapHub<ChatHub>(EndPoints.Hub.ChatHubPath);

app.Run();


