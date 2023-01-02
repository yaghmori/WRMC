using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class AppSettingsRequest
    {
        [Required]
        public string Key { get; set; } = string.Empty;
        [Required]
        public string Value { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool? IsReadOnly { get; set; }
    }
}
