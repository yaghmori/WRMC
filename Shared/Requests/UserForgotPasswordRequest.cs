using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class UserForgotPasswordRequest

    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

    }
}
