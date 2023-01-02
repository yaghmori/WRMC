using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class UserTenantRequest
    {

        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid TenantId { get; set; }
    }

}
