using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using WRMC.Core.Shared.Extensions;
using WRMC.Core.Shared.PagedCollections;
using WRMC.Core.Shared.Requests;
using WRMC.Core.Shared.Responses;
using WRMC.Core.Shared.ResultWrapper;
using WRMC.Core.Shared.Constants;

namespace WRMC.Core.Application.DataServices
{

    public class UserDataService : DataServiceBase, IUserDataService
    {
        public UserDataService(IHttpClientFactory httpClient) : base(httpClient)
        {
        }


        #region Users
        public async Task<IResult<string>> CreateNewUserAsync(NewUserRequest request)
        {
            var uri = string.Format(EndPoints.UserController.AddNewUser);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }
        public async Task<IResult<UserResponse>> GetUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<UserResponse>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetUserById, userId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<UserResponse>();
        }
        public async Task<IResult<List<UserResponse>>> GetUsersAsync(string? query = null)
        {
            var uri = EndPoints.UserController.GetUsers;
            uri = QueryHelpers.AddQueryString(uri, "paged", "false");
            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);

            List<UserResponse> result = new List<UserResponse>();
            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<UserResponse>>();

        }
        public async Task<IResult<IPagedList<UserResponse>>> GetUsersPagedAsync(int page = 0, int pageSize = 10, string query = null)
        {
            var uri = EndPoints.UserController.GetUsers;

            //uri = QueryHelpers.AddQueryString(uri, "paged", "true");

            uri = QueryHelpers.AddQueryString(uri, "page", page.ToString());
            uri = QueryHelpers.AddQueryString(uri, "pageSize", pageSize.ToString());
            if (!string.IsNullOrWhiteSpace(query))
                uri = QueryHelpers.AddQueryString(uri, nameof(query), query);


            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<PagedList<UserResponse>>();
        }
        public async Task<IResult<bool>> DeleteUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.DeleteUserById, userId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }
        public async Task<IResult<bool>> ChangePasswordAsync(string userId, ChangePasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.ChangePassword, userId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<bool>();
        }
        public async Task<IResult<bool>> SetPasswordAsync(string userId, PasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.AuthController.SetPassword, userId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<bool>();
        }
        public async Task<IResult<bool>> UpdateUserAsync(string userId, JsonPatchDocument<UserRequest> request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.UpdateUserById, userId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }
        public async Task<IResult<bool>> CheckIfEmailExist(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return await Result<bool>.FailAsync("Invalid request.");

            var uri = EndPoints.UserController.CheckIfEmailExist;
            uri = QueryHelpers.AddQueryString(uri, nameof(email), email);

            var response = await _httpClient.GetAsync(uri);

            return await response.ToResult<bool>();
        }

        #endregion

        #region userRoles
        public async Task<IResult<List<UserRoleResponse>>> GetUserRolesAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<List<UserRoleResponse>>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetUserRoles, userId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<UserRoleResponse>>();
        }
        public async Task<IResult<bool>> UpdateUserRolesAsync(string userId, List<string> roles)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.UpdateUserRoles, userId);

            var content = new StringContent(JsonConvert.SerializeObject(roles), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(uri, content);
            return await response.ToResult<bool>();
        }
        #endregion

        #region UserClaims
        public async Task<IResult<List<ClaimResponse>>> GetUserClaimsAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<List<ClaimResponse>>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetUserClaims, userId);
            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<ClaimResponse>>();
        }
        public async Task<IResult<bool>> UpdateUserClaimsAsync(string userId, List<ClaimRequest> claims)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.UpdateUserClaims, userId);

            var content = new StringContent(JsonConvert.SerializeObject(claims), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(uri, content);
            return await response.ToResult<bool>();

        }
        #endregion

        #region UserSessions
        public async Task<IResult<List<UserSessionResponse>>> GetUserSessionsAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<List<UserSessionResponse>>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetUserSessions, userId);
            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<UserSessionResponse>>();
        }
        public async Task<IResult<bool>> TerminateSessionAsync(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
                return await Result<bool>.FailAsync("SessionId is null or empty.");

            var uri = string.Format(EndPoints.UserController.TerminateSession, sessionId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }
        #endregion

        #region UserSettings
        public async Task<IResult<UserSettingResponse>> GetUserSettingAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<UserSettingResponse>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetUserSetting, userId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<UserSettingResponse>();
        }
        public async Task<IResult<string>> AddUserSettingAsync(string userId, UserSettingRequest request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<string>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.AddUserSetting, userId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }
        public async Task<IResult<bool>> UpdateUserSettingsAsync(string userId, JsonPatchDocument<UserSettingRequest> request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.UpdateUserSetting, userId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }
        public async Task<IResult<bool>> DeleteUserSettingsAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.DeleteUserSetting, userId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }
        #endregion

        #region UserProfile
        public async Task<IResult<UserProfileResponse>> GetUserProfileAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<UserProfileResponse>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetUserProfile, userId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<UserProfileResponse>();
        }
        public async Task<IResult<string>> AddUserProfileAsync(string userId, UserProfileRequest request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<string>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.AddUserProfile, userId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }
        public async Task<IResult<bool>> UpdateUserProfileAsync(string userId, JsonPatchDocument<UserProfileRequest> request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.UpdateUserProfile, userId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }
        public async Task<IResult<bool>> DeleteUserProfileAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.DeleteUserProfile, userId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        #endregion

        #region UserPhoneNumbers
        public async Task<IResult<List<UserPhoneNumberResponse>>> GetUserPhoneNumbersAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<List<UserPhoneNumberResponse>>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetPhoneNumbers, userId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<UserPhoneNumberResponse>>();
        }

        public async Task<IResult<UserPhoneNumberResponse>> GetUserPhoneNumberAsync(string userId, string phoneNumberId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<UserPhoneNumberResponse>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetPhoneNumber, userId, phoneNumberId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<UserPhoneNumberResponse>();
        }

        public async Task<IResult<string>> AddUserPhoneNumberAsync(string userId, UserPhoneNumberRequest request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<string>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.AddPhoneNumber, userId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<bool>> UpdateUserPhoneNumberAsync(string userId, string phoneNumberId, JsonPatchDocument<UserPhoneNumberRequest> request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            if (string.IsNullOrWhiteSpace(phoneNumberId))
                return await Result<bool>.FailAsync("PhoneNumberId is null or empty.");

            var uri = string.Format(EndPoints.UserController.UpdatePhoneNumber, userId, phoneNumberId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteUserPhoneNumberAsync(string userId, string phoneNumberId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.DeletePhoneNumber, userId, phoneNumberId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        #endregion

        #region UserAddresses
        public async Task<IResult<List<UserAddressResponse>>> GetUserAddressesAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<List<UserAddressResponse>>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetAddresses, userId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<UserAddressResponse>>();
        }

        public async Task<IResult<UserAddressResponse>> GetUserAddressAsync(string userId, string addressId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<UserAddressResponse>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetAddress, userId, addressId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<UserAddressResponse>();
        }

        public async Task<IResult<string>> AddUserAddressAsync(string userId, UserAddressRequest request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<string>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.AddAddress, userId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<bool>> UpdateUserAddressAsync(string userId, string addressId, JsonPatchDocument<UserAddressRequest> request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            if (string.IsNullOrWhiteSpace(addressId))
                return await Result<bool>.FailAsync("AddressId is null or empty.");

            var uri = string.Format(EndPoints.UserController.UpdateAddress, userId, addressId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json-patch+json");
            var response = await _httpClient.PatchAsync(uri, content);
            return await response.ToResult<bool>();
        }


        public async Task<IResult<bool>> DeleteUserAddressAsync(string userId, string addressId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.DeleteAddress, userId, addressId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        #endregion

        #region UserAddresses
        public async Task<IResult<List<UserAttachmentResponse>>> GetUserAttachmentsAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<List<UserAttachmentResponse>>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetAttachments, userId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<List<UserAttachmentResponse>>();
        }

        public async Task<IResult<UserAttachmentResponse>> GetUserAttachmentAsync(string userId, string attachmentId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<UserAttachmentResponse>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.GetAttachment, userId, attachmentId);

            var response = await _httpClient.GetAsync(uri);
            return await response.ToResult<UserAttachmentResponse>();
        }

        public async Task<IResult<string>> AddUserAttachmentAsync(string userId, UserAttachmentRequest request)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<string>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.AddAttachment, userId);

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            return await response.ToResult<string>();
        }

        public async Task<IResult<bool>> DeleteUserAttachmentAsync(string userId, string attachmentId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return await Result<bool>.FailAsync("UserId is null or empty.");

            var uri = string.Format(EndPoints.UserController.DeleteAttachment, userId, attachmentId);
            var response = await _httpClient.DeleteAsync(uri);
            return await response.ToResult<bool>();
        }

        #endregion

    }
}
