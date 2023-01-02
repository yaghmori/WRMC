using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class TenantRequest
    {
        [Required]
        public string Name { get; set; }
        public string NormalizedName => Name.Normalize().ToUpper();
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        [Required]
        public string ConnectionString { get; set; }= string.Empty;
        [Required]
        public DateTime? ExpireDate { get; set; }

    }

}
