namespace WRMC.Core.Shared.Models
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; }=string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string TokenExpiryInMinutes { get; set; } = string.Empty;
        public bool ValidateLifetime { get; set; } = false;
        public bool ValidateIssuerSigningKey { get; set; } = false;
        public bool ValidateIssuer { get; set; } = false;
        public bool ValidateAudience { get; set; } = false;
        public string RefreshTokenExpiryInDay { get; set; } =  string.Empty;
    }
    public class SmtpSettings
    {
        public string Host { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Port { get; set; } = 587;
    }

}
