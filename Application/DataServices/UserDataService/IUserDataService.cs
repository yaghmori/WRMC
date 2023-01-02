using Microsoft.AspNetCore.JsonPatch;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;

namespace WRMC.Core.Application.DataServices
{
    public interface IUserDataService
    {
        Task<IResult<string>> AddUserAddressAsync(string userId, UserAddressRequest request);
        Task<IResult<string>> AddUserAttachmentAsync(string userId, UserAttachmentRequest request);
        Task<IResult<string>> AddUserPhoneNumberAsync(string userId, UserPhoneNumberRequest request);
        Task<IResult<string>> AddUserProfileAsync(string userId, UserProfileRequest request);
        Task<IResult<string>> AddUserSettingAsync(string userId, UserSettingRequest request);
        Task<IResult<bool>> ChangePasswordAsync(string userId, ChangePasswordRequest request);
        Task<IResult<string>> CreateNewUserAsync(NewUserRequest request);
        Task<IResult<bool>> DeleteUserAddressAsync(string userId, string addressId);
        Task<IResult<bool>> DeleteUserAsync(string userId);
        Task<IResult<bool>> DeleteUserAttachmentAsync(string userId, string attachmentId);
        Task<IResult<bool>> DeleteUserPhoneNumberAsync(string userId, string phoneNumberId);
        Task<IResult<bool>> DeleteUserProfileAsync(string userId);
        Task<IResult<bool>> DeleteUserSettingsAsync(string userId);
        Task<IResult<UserAddressResponse>> GetUserAddressAsync(string userId, string addressId);
        Task<IResult<List<UserAddressResponse>>> GetUserAddressesAsync(string userId);
        Task<IResult<UserResponse>> GetUserAsync(string userId);
        Task<IResult<UserAttachmentResponse>> GetUserAttachmentAsync(string userId, string attachmentId);
        Task<IResult<List<UserAttachmentResponse>>> GetUserAttachmentsAsync(string userId);
        Task<IResult<List<UserClaimResponse>>> GetUserClaimsAsync(string userId);
        Task<IResult<UserPhoneNumberResponse>> GetUserPhoneNumberAsync(string userId, string phoneNumberId);
        Task<IResult<List<UserPhoneNumberResponse>>> GetUserPhoneNumbersAsync(string userId);
        Task<IResult<UserProfileResponse>> GetUserProfileAsync(string userId);
        Task<IResult<List<UserRoleResponse>>> GetUserRolesAsync(string userId);
        Task<IResult<List<UserResponse>>> GetUsersAsync(string? query = null);
        Task<IResult<List<UserSessionResponse>>> GetUserSessionsAsync(string userId);
        Task<IResult<UserSettingResponse>> GetUserSettingAsync(string userId);
        Task<IResult<IPagedList<UserResponse>>> GetUsersPagedAsync(int page = 0, int pageSize = 10, string query = null);
        Task<IResult<List<UserTenantResponse>>> GetUserTenantsAsync(string userId);
        Task<IResult<bool>> SetPasswordAsync(string userId, PasswordRequest request);
        Task<IResult<bool>> TerminateSessionAsync(string sessionId);
        Task<IResult<bool>> UpdateUserAsync(string userId, JsonPatchDocument<UserRequest> request);
        Task<IResult<bool>> UpdateUserClaimsAsync(string userId, List<UserClaimRequest> claims);
        Task<IResult<bool>> UpdateUserProfileAsync(string userId, JsonPatchDocument<UserProfileRequest> request);
        Task<IResult<bool>> UpdateUserRolesAsync(string userId, List<string> roles);
        Task<IResult<bool>> UpdateUserSettingsAsync(string userId, JsonPatchDocument<UserSettingRequest> request);
        Task<IResult<bool>> UpdateUserTenantsAsync(string userId, List<string> tenants);
        Task<IResult<bool>> UpdateUserAddressAsync(string userId, string addressId, JsonPatchDocument<UserAddressRequest> request);
        Task<IResult<bool>> UpdateUserPhoneNumberAsync(string userId, string phoneNumberId, JsonPatchDocument<UserPhoneNumberRequest> request);
    }
}