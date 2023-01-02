using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        [Compare(nameof(Password))]
        public string PasswordConfirmation { get; set; } = string.Empty;


        public string NormalizedEmail => Email.Normalize().ToUpper();
        public string UserName => Email;
        public string NormalizedUserName => UserName.Normalize().ToUpper();
        public string SecurityStamp => Guid.NewGuid().ToString();
        public string ConcurrencyStamp => Guid.NewGuid().ToString();

    }

}
