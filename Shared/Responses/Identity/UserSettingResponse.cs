namespace WRMC.Core.Shared.Responses
{
    public class UserSettingResponse
    {
        public string Id { get; set; }
        public string Theme { get; set; } = string.Empty;
        public bool RightToLeft { get; set; } = false;
        public bool DarkMode { get; set; } = false;
        public string Culture { get; set; } = "en-US";
        public string? UserId { get; set; } = string.Empty;
    }
}
