using System.ComponentModel.DataAnnotations;

namespace WRMC.Core.Shared.Requests
{
    public class SignInByUserNameRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        [RegularExpression("([0-9]+)")]
        public bool IsPersistent { get; set; }
        public string NormalizedUsername => Username.Normalize().ToUpper();

    }
    public class SignInByPhoneNumberRequest
    {
        [Required]
        [RegularExpression("([0-9]+)")]
        public string PhoneNumber { get; set; } = string.Empty;
        public bool IsPersistent { get; set; }
    }
    public class LoginByEmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        
        public bool IsPersistent { get; set; }
    }

}
