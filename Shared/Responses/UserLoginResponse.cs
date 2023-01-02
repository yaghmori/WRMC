namespace WRMC.Core.Shared.Responses
{
    public class UserLoginResponse
    {
        public string Id { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string AccessToken { get; set; } = default!;
        public string LoginProvider { get; set; } = default!;
        public string ProviderKey { get; set; } = default!;
        
        public string RefreshToken { get; set; } = default!;
        public DateTime? RefreshTokenExpires { get; set; }

    }

}
