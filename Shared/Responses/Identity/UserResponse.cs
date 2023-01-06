namespace WRMC.Core.Shared.Responses
{
    public class UserResponse : BaseUserResponse
    {

        public UserSettingResponse UserSetting { get; set; } = new();
        public UserProfileResponse UserProfile { get; set; } = new();
        public int RolesCount { get; set; } = default!;
        public int TenantsCount { get; set; } = default!;
        public int ClaimsCount { get; set; } = default!;
        public int SessionsCount { get; set; } = default!;
        public int PhoneNumbersCount { get; set; } = default!;
        public int ImagesCount { get; set; } = default!;
        public int AddressesCount { get; set; } = default!;








    }
}
