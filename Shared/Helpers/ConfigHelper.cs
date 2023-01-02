using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WRMC.Core.Shared.Models;

namespace WRMC.Core.Shared.Helpers
{
    public static class ConfigHelper
    {
        private static IConfiguration config;
        private static IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                config = builder.Build();
                return config;
            }
        }

        public static TokenValidationParameters ValidationParameters
        {
            get
            {
                return new TokenValidationParameters
                {
                    ValidateAudience = JwtSettings.ValidateAudience,
                    ValidateIssuer = JwtSettings.ValidateIssuer,
                    ValidateIssuerSigningKey = JwtSettings.ValidateIssuerSigningKey,
                    ValidateLifetime = true,
                    ValidIssuer = JwtSettings.Issuer,
                    ValidAudience = JwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecurityKey)),
                    ClockSkew = TimeSpan.Zero,
                };
            }

        }

        public static JwtSettings JwtSettings
        {
            get
            {
                return new JwtSettings
                {
                    TokenExpiryInMinutes = Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.TokenExpiryInMinutes)}"],
                    SecurityKey = Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.SecurityKey)}"],
                    Audience = Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.Audience)}"],
                    Issuer = Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.Issuer)}"],
                    ValidateAudience = Convert.ToBoolean(Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.ValidateAudience)}"]),
                    ValidateIssuer = Convert.ToBoolean(Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.ValidateIssuer)}"]),
                    ValidateIssuerSigningKey = Convert.ToBoolean(Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.ValidateIssuerSigningKey)}"]),
                    ValidateLifetime = Convert.ToBoolean(Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.ValidateLifetime)}"]),
                    RefreshTokenExpiryInDay = Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.RefreshTokenExpiryInDay)}"],
                };
            }
        }
        public static SmtpSettings SmtpSettings
        {
            get
            {
                return new SmtpSettings
                {
                    Host = Configuration[$"{nameof(Models.SmtpSettings)}:{nameof(Models.SmtpSettings.Host)}"],
                    Username = Configuration[$"{nameof(Models.SmtpSettings)}:{nameof(Models.SmtpSettings.Username)}"],
                    Password = Configuration[$"{nameof(Models.SmtpSettings)}:{nameof(Models.SmtpSettings.Password)}"],
                    Port = Convert.ToInt32(Configuration[$"{nameof(Models.SmtpSettings)}:{nameof(Models.SmtpSettings.Port)}"]),
                };
            }
        }

        public static void SetSection(string key, string value)
        {
            Configuration[key] = value;
        }
        public static void SetJwtSettings(JwtSettings settings)
        {
            Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.TokenExpiryInMinutes)}"] = settings.TokenExpiryInMinutes;
            Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.RefreshTokenExpiryInDay)}"] = settings.RefreshTokenExpiryInDay;
            Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.SecurityKey)}"] = settings.SecurityKey;
            Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.Audience)}"] = settings.Audience;
            Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.Issuer)}"] = settings.Issuer;
            Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.ValidateAudience)}"] = settings.ValidateAudience.ToString();
            Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.ValidateIssuer)}"] = settings.ValidateIssuer.ToString();
            Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.ValidateIssuerSigningKey)}"] = settings.ValidateIssuerSigningKey.ToString();
            Configuration[$"{nameof(Models.JwtSettings)}:{nameof(Models.JwtSettings.ValidateLifetime)}"] = settings.ValidateLifetime.ToString();
        }
        public static void SetSmtpSettings(SmtpSettings settings)
        {
            Configuration[$"{nameof(Models.SmtpSettings)}:{nameof(Models.SmtpSettings.Host)}"] = settings.Host;
            Configuration[$"{nameof(Models.SmtpSettings)}:{nameof(Models.SmtpSettings.Username)}"] = settings.Username;
            Configuration[$"{nameof(Models.SmtpSettings)}:{nameof(Models.SmtpSettings.Password)}"] = settings.Password;
            Configuration[$"{nameof(Models.SmtpSettings)}:{nameof(Models.SmtpSettings.Port)}"] = settings.Port.ToString();
        }

    }
}
