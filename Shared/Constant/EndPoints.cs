namespace WRMC.Core.Shared.Constant
{

    public static class EndPoints
    {
        public const string TenantEndPoint = "/api/v1/Tenants";
        public const string ServerEndPoint = "/api/v1/server";

        public static class Hub
        {
            //====================== Users ==================================
            public const string MainHubPath = "/Hubs/MainHub";
            public const string ChatHubPath = "/Hubs/ChatHub";
            //====================== Dashboard ==================================
            public const string SendUpdateDashboard = "UpdateDashboardAsync";
            public const string ReceiveUpdateDashboard = "UpdateDashboard";
            //====================== Token ==================================
            public const string SendRegenerateTokens = "RegenerateTokensAsync";
            public const string ReceiveRegenerateTokens = "RegenerateTokens";
            public const string SendUpdateAuthState = "UpdateAuthStateAsync";
            public const string ReceiveUpdateAuthState = "UpdateAuthState";
            public const string SendTerminateSession = "TerminateSessionAsync";
            public const string ReceiveTerminateSession = "TerminateSession";
            public const string SendUpdateUser = "UpdateUserAsync";
            public const string ReceiveUpdateUser = "UpdateUpdateUser";

            //====================== Chat ==================================
            public const string SendChatNotification = "ChatNotificationAsync";
            public const string ReceiveChatNotification = "ReceiveChatNotification";
            public const string ReceiveMessage = "ReceiveMessage";
            public const string SendMessage = "SendMessageAsync";
            //==================Culture==============================
            public const string SendUpdateCulture = "UpdateCultureAsync";
            public const string ReceiveUpdateCulture = "UpdateCulture";


        }
        public static class UserController
        {
            public const string GetUsers = ServerEndPoint + "/users";
            public const string GetUserById = ServerEndPoint + "/users/{0}";
            public const string AddNewUser = ServerEndPoint + "/users/New";
            public const string UpdateUserById = ServerEndPoint + "/users/{0}";
            public const string ChangePassword = ServerEndPoint + "/users/{0}/change-password";
            public const string DeleteUserById = ServerEndPoint + "/users/{0}";
            //===============================UserClaims==================================
            public const string GetUserClaims = ServerEndPoint + "/users/{0}/Claims";
            public const string UpdateUserClaims = ServerEndPoint + "/users/{0}/Claims";
            //===============================UserTenants==================================
            public const string GetUserTenants = ServerEndPoint + "/users/{0}/Tenants";
            public const string UpdateUserTenants = ServerEndPoint + "/users/{0}/Tenants";
            //===============================UserRoles==================================
            public const string GetUserRoles = ServerEndPoint + "/users/{0}/Roles";
            public const string UpdateUserRoles = ServerEndPoint + "/users/{0}/Roles";
            public const string AddRoleToUserByRoleId = ServerEndPoint + "/users/{0}/Roles/{1}";
            public const string RemoveRoleFromUserByRoleId = ServerEndPoint + "/users/Roles/{1}";
            //===============================UserSessions==================================
            public const string GetUserSessions = ServerEndPoint + "/users/{0}/sessions";
            public const string TerminateSession = ServerEndPoint + "/users/sessions/{0}";
            //===============================UserSettings==================================
            public const string GetUserSetting = ServerEndPoint + "/users/{0}/Settings";
            public const string AddUserSetting = ServerEndPoint + "/users/{0}/Settings";
            public const string UpdateUserSetting = ServerEndPoint + "/users/{0}/Settings";
            public const string DeleteUserSetting = ServerEndPoint + "/users/{0}/Settings";
            //===============================UserProfile==================================
            public const string GetUserProfile = ServerEndPoint + "/users/{0}/UserProfile";
            public const string AddUserProfile = ServerEndPoint + "/users/{0}/UserProfile";
            public const string UpdateUserProfile = ServerEndPoint + "/users/{0}/UserProfile";
            public const string DeleteUserProfile = ServerEndPoint + "/users/{0}/UserProfile";
            //==============================UserPhoneNumber===============================
            public const string AddPhoneNumber = ServerEndPoint + "/users/{0}/PhoneNumbers";
            public const string GetPhoneNumbers = ServerEndPoint + "/users/{0}/PhoneNumbers";
            public const string GetPhoneNumber = ServerEndPoint + "/users/{0}/PhoneNumbers/{1}";
            public const string DeletePhoneNumber = ServerEndPoint + "/users/{0}/PhoneNumbers/{1}";
            public const string UpdatePhoneNumber = ServerEndPoint + "/users/{0}/PhoneNumbers/{1}";
            //===============================UserAddress==================================
            public const string AddAddress = ServerEndPoint + "/users/{0}/Addresses";
            public const string GetAddresses = ServerEndPoint + "/users/{0}/Addresses";
            public const string GetAddress = ServerEndPoint + "/users/{0}/Addresses/{1}";
            public const string DeleteAddress = ServerEndPoint + "/users/{0}/Addresses/{1}";
            public const string UpdateAddress = ServerEndPoint + "/users/{0}/Addresses/{1}";

            //==============================UserAttachment=================================
            public const string AddAttachment = ServerEndPoint + "/users/{0}/Attachments";
            public const string GetAttachments = ServerEndPoint + "/users/{0}/Attachments";
            public const string GetAttachment = ServerEndPoint + "/users/{0}/Attachments/{1}";
            public const string DeleteAttachment = ServerEndPoint + "/users/{0}/Attachments/{1}";



        }
        public static class AuthController
        {
            public const string RefreshToken = ServerEndPoint + "/auth/token/refresh";
            public const string GetToken = ServerEndPoint + "/auth/token";
            public const string Register = ServerEndPoint + "/auth/Register";


            public const string RegisterByEmail = ServerEndPoint + "/auth/RegisterByEmail";
            public const string RegisterByPhoneNumber = ServerEndPoint + "/auth/RegisterByPhoneNumber";
            public const string IsDupplicateByUserName = ServerEndPoint + "/auth/UserName";
            public const string IsDupplicateByEmail = ServerEndPoint + "/auth/Email";
            public const string IsDupplicateByPhoneNumber = ServerEndPoint + "/auth/PhoneNumber";
            public const string VerifyPhoneNumber = ServerEndPoint + "/auth/Verify-PhoneNumber";
            public const string VerifyEmail = ServerEndPoint + "/auth/Verify-email";
            public const string TwoFactorLoginByPhoneNumber = ServerEndPoint + "/Auth/Login/TwoFactor/PhoneNumber";
            public const string TwoFactorLoginByEmail = ServerEndPoint + "/Auth/Login/TwoFactor/Email?email={0}";
            public const string Logout = ServerEndPoint + "/Auth/Logout";
            public const string ForgotPasswordByUserId = ServerEndPoint + "/Auth/{0}/Forgot-Password/";
            public const string ForgotPasswordByPhoneNumber = ServerEndPoint + "/Auth/Forgot-Password/PhoneNumber?phoneNumber={0}";
            public const string ForgotPasswordByUserName = ServerEndPoint + "/Auth/Forgot-Password/UserName?userName={0}";
            public const string ForgotPasswordByEmail = ServerEndPoint + "/Auth/Forgot-Password/Email?email={0}";
            public const string ResetPassword = ServerEndPoint + "/Auth/{0}/Reset-Password";
            public const string SetPassword = ServerEndPoint + "/Auth/{0}/set-Password";
            public const string UpdateSecurityStamp = ServerEndPoint + "/Auth/UpdateSecurityStamp/{0}";
        }
        public static class TenantController
        {

            public const string GetTenants = ServerEndPoint + "/Tenants";
            public const string GetTenantById = ServerEndPoint + "/Tenants/{0}";
            public const string GetUsersByTenantId = ServerEndPoint + "/Tenants/{0}/users";
            public const string AddTenant = ServerEndPoint + "/Tenants";
            public const string AddUserToTenant = ServerEndPoint + "/Tenants/{0}/users/{1}";
            public const string RemoveUserFromTenant = ServerEndPoint + "/Tenants/{0}/users/{1}";
            public const string DeleteUserTenantById = ServerEndPoint + "/UserTenants/{0}";
            public const string DeleteTenantById = ServerEndPoint + "/Tenants/{0}";
            public const string UpdateTenantById = ServerEndPoint + "/Tenants/{0}";
            public const string ReplaceTenantUsers = ServerEndPoint + "/Tenants/{0}/users";
            public const string CreateDataBase = ServerEndPoint + "/Tenants/{0}/EnsureCreated";
            public const string DeleteDataBase = ServerEndPoint + "/Tenants/{0}/EnsureDeleted";
            public const string MigrateDataBase = ServerEndPoint + "/Tenants/{0}/Migrate";
        }
        public static class AppSettingController
        {
            public const string GetAppSettings = ServerEndPoint + "/AppSettings";
            public const string GetAppSettingById = ServerEndPoint + "/AppSettings/{0}";
            public const string GetAppSettingByKey = ServerEndPoint + "/AppSettings/keys";
            public const string AddAppSetting = ServerEndPoint + "/AppSettings";
            public const string DeleteAppSettingById = ServerEndPoint + "/AppSettings/{0}";
            public const string DeleteAppSettingByKey = ServerEndPoint + "/AppSettings/keys";
            public const string UpdateAppSettingById = ServerEndPoint + "/AppSettings/{0}";
        }
        public static class SectionController
        {
            public const string CreateNewSection = ServerEndPoint + "/sections";
            public const string GetSections = ServerEndPoint + "/sections";
            public const string GetSectionById = ServerEndPoint + "/sections/{0}";
            public const string GetParentSection = ServerEndPoint + "/sections/{0}/parent";
            public const string UpdateSectionById = ServerEndPoint + "/sections/{0}";
            public const string DeleteSectionById = ServerEndPoint + "/sections/{0}";
            public const string GetSectionClaims = ServerEndPoint + "/sections/{0}/claims";
            public const string AddSectionClaim = ServerEndPoint + "/sections/{0}/claims";
            public const string UpdateSectionClaims = ServerEndPoint + "/sections/{0}/claims";
            public const string DeleteAllSections = ServerEndPoint + "/sections/reset";
        }
        public static class RegionController
        {
            public const string AddNewRegion = ServerEndPoint + "/Regions";
            public const string GetRegions = ServerEndPoint + "/Regions";
            public const string GetRegion = ServerEndPoint + "/Regions/{0}";
            public const string SearchRegions = ServerEndPoint + "/Regions/Search";//query
            public const string GetParentRegion = ServerEndPoint + "/Regions/{0}/parent";
            public const string UpdateRegion = ServerEndPoint + "/Regions/{0}";
            public const string DeleteRegion = ServerEndPoint + "/Regions/{0}";
            public const string DeleteAllRegions = ServerEndPoint + "/Regions/reset";
        }

        public static class IntroMethodController
        {
            public const string CreateNewIntroMethod = ServerEndPoint + "/IntroMethods";
            public const string GetIntroMethods = ServerEndPoint + "/IntroMethods";
            public const string GetIntroMethodById = ServerEndPoint + "/IntroMethods/{0}";
            public const string GetParentIntroMethod = ServerEndPoint + "/IntroMethods/{0}/parent";
            public const string UpdateIntroMethodById = ServerEndPoint + "/IntroMethods/{0}";
            public const string DeleteIntroMethodById = ServerEndPoint + "/IntroMethods/{0}";
            public const string DeleteAllIntroMethods = ServerEndPoint + "/IntroMethods/reset";
        }
        public static class CaseController
        {
            public const string CreateNewCase = ServerEndPoint + "/cases";
            public const string UpdateCaseById = ServerEndPoint + "/cases/{0}";
            public const string GetCases = ServerEndPoint + "/cases";
            public const string GetCaseById = ServerEndPoint + "/cases/{0}";
            public const string DeleteCaseById = ServerEndPoint + "/cases/{0}";

        }
        public static class VisitController
        {
            //===============================Visits==========================================
            public const string CreateNewVisit = ServerEndPoint + "/visits";
            public const string UpdateVisitById = ServerEndPoint + "/visits/{0}";
            public const string GetVisits = ServerEndPoint + "/visits";
            public const string GetVisitById = ServerEndPoint + "/visits/{0}";
            public const string GetUserByVisitId = ServerEndPoint + "/visits/{0}/User";
            public const string GetVisitByTaskId = ServerEndPoint + "/visits/Tasks/{0}/Visit";
            public const string GetUserByTaskId = ServerEndPoint + "/visits/Tasks/{0}/User";
            public const string DeleteVisitById = ServerEndPoint + "/visits/{0}";
            //===========================Tasks=======================================
            public const string GetTasks = ServerEndPoint + "/visits/{0}/Tasks";
            public const string GetTaskById = ServerEndPoint + "/visits/Tasks/{0}";
            public const string AddTask = ServerEndPoint + "/visits/{0}/Tasks/{1}";
            public const string DeleteTask = ServerEndPoint + "/visits/Tasks/{0}";
            public const string UpdateTask = ServerEndPoint + "/visits/Tasks/{0}";
            //===========================MedicalIntakes====================================
            public const string AddMedicalIntake = ServerEndPoint + "/visits/{0}/MedicalIntakes";
            public const string GetMedicalIntakes = ServerEndPoint + "/visits/{0}/MedicalIntakes";
            public const string DeleteMedicalIntake = ServerEndPoint + "/visits/MedicalIntakes/{0}";
            //=========================DemographicIntake=====================================
            public const string AddDemographicIntake = ServerEndPoint + "/visits/{0}/DemographicIntake";
            public const string GetDemographicIntake = ServerEndPoint + "/visits/{0}/DemographicIntake";
            public const string DeleteDemographicIntake = ServerEndPoint + "/visits/DemographicIntake/{0}";
        }

        public static class DemographicIntakesController
        {
            public const string GetDemographicIntakes = ServerEndPoint + "/intakes/demographics";
            public const string GetDemographicIntakeById = ServerEndPoint + "/intakes/demographics/{0}";
            public const string GetDemographicIntakeByTaskId = ServerEndPoint + "/intakes/demographics/tasks/{0}";
            public const string AddDemographicIntake = ServerEndPoint + "/intakes/demographics";
            public const string CreateDemographicIntake = ServerEndPoint + "/intakes/demographics/new";
            public const string UpdateDemographicIntakeById = ServerEndPoint + "/intakes/demographics/{0}";
            public const string DeleteDemographicIntakeById = ServerEndPoint + "/intakes/demographics/{0}";
        }
        public static class MedicalIntakesController
        {
            public const string GetMedicalIntakes = ServerEndPoint + "/intakes/medicals";
            public const string GetMedicalIntakeById = ServerEndPoint + "/intakes/medicals/{0}";
            public const string GetMedicalIntakeByTaskId = ServerEndPoint + "/intakes/medicals/tasks/{0}";
            public const string AddMedicalIntake = ServerEndPoint + "/intakes/medicals";
            public const string CreateMedicalIntake = ServerEndPoint + "/intakes/medicals/new";
            public const string UpdateMedicalIntakeById = ServerEndPoint + "/intakes/medicals/{0}";
            public const string DeleteMedicalIntakeById = ServerEndPoint + "/intakes/medicals/{0}";
        }
        public static class UserSettingController
        {
            public const string GetUserSettings = ServerEndPoint + "/UserSettings";
            public const string GetUserSettingById = ServerEndPoint + "/UserSettings/{0}";
            public const string AddUserSetting = ServerEndPoint + "/UserSettings";
            public const string GetUserSettingByUserId = ServerEndPoint + "/UserSettings/users/{0}";
            public const string DeleteUserSettingById = ServerEndPoint + "/UserSettings/{0}";
            public const string UpdateUserSettingById = ServerEndPoint + "/UserSettings/{0}";
        }
        public static class RoleController
        {
            public const string GetRoles = ServerEndPoint + "/roles";
            public const string GetRoleClaims = ServerEndPoint + "/roles/{0}/claims";
            public const string GetRoleById = ServerEndPoint + "/roles/{0}";
            public const string GetRoleByName = ServerEndPoint + "/roles/{0}";
            public const string AddRole = ServerEndPoint + "/roles/{0}";
            public const string DeleteRoleById = ServerEndPoint + "/roles/{0}";
            public const string DeleteRoleByName = ServerEndPoint + "/roles/{0}";
            public const string UpdateRoleById = ServerEndPoint + "/roles/{0}";
            public const string GetUsersByRoleId = ServerEndPoint + "/roles/{0}/users";
            public const string GetUsersByRoleName = ServerEndPoint + "/roles/{0}/users";
            public const string GetRolesByUserId = ServerEndPoint + "/roles/users";
            public const string UpdateUserRoles = ServerEndPoint + "/roles/{0}/users";
            public const string UpdateRoleClaims = ServerEndPoint + "/roles/{0}/claims";
        }
        public static class CultureController
        {
            public const string GetCultures = ServerEndPoint + "/cultures";
            public const string GetCultureById = ServerEndPoint + "/cultures/{0}";
            public const string AddCulture = ServerEndPoint + "/cultures";
            public const string DeleteCultureById = ServerEndPoint + "/cultures/{0}";
            public const string UpdateCultureById = ServerEndPoint + "/cultures/{0}";
        }
        public static class ClaimController
        {
            public const string GetClaims = ServerEndPoint + "/claims";
            public const string GetClaimById = ServerEndPoint + "/claims/{0}";
            public const string AddCalim = ServerEndPoint + "/claims";
            public const string DeleteClaimById = ServerEndPoint + "/claims/{0}";
            public const string UpdateClaimById = ServerEndPoint + "/claims/{0}";
        }










    }
}
