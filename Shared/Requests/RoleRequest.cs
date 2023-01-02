using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class RoleRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
