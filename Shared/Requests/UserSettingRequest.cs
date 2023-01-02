using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class UserSettingRequest
    {
        [Required]
        public string UserId { get; set; }
        public string? DefaultTenantId { get; set; }
        public string Theme { get; set; } = string.Empty;
        public bool RightToLeft { get; set; } = false;
        public bool DarkMode { get; set; } = false;
        public string Culture { get; set; } = "en-US";

    }
}
