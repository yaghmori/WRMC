namespace WRMC.Core.Shared.Constants
{

    public static class EndPoints
    {
        public const string TenantEndPoint = "/api/v1/tenants";
        public const string ServerEndPoint = "/api/v1/server";
        public const string MainHub = "/Hubs/MainHub";
        public const string ChatHub = "/Hubs/ChatHub";

        #region Server EndPoints

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
        public static class UserController
        {
            public const string GetUsers = ServerEndPoint + "/users";
            public const string GetUserById = ServerEndPoint + "/users/{0}";
            public const string AddNewUser = ServerEndPoint + "/users/New";
            public const string UpdateUserById = ServerEndPoint + "/users/{0}";
            public const string ChangePassword = ServerEndPoint + "/users/{0}/change-password";
            public const string DeleteUserById = ServerEndPoint + "/users/{0}";
            public const string CheckIfEmailExist = ServerEndPoint + "/users/emails";

            //===============================UserClaims==================================
            public const string GetUserClaims = ServerEndPoint + "/users/{0}/claims";
            public const string UpdateUserClaims = ServerEndPoint + "/users/{0}/claims";
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
            public const string CheckIfNameExist = ServerEndPoint + "/roles/names";
            public const string GetRoleClaims = ServerEndPoint + "/roles/{0}/claims";
            public const string GetRoleById = ServerEndPoint + "/roles/{0}";
            public const string GetRoleByName = ServerEndPoint + "/roles/{0}";
            public const string AddRole = ServerEndPoint + "/roles/{0}";
            public const string DeleteRoleById = ServerEndPoint + "/roles/{0}";
            public const string DeleteRoleByName = ServerEndPoint + "/roles/{0}";
            public const string UpdateRoleById = ServerEndPoint + "/roles/{0}";
            public const string GetRoleUsers = ServerEndPoint + "/roles/{0}/users";
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
        public static class TenantController
        {

            public const string GetTenants = ServerEndPoint + "/tenants";
            public const string GetTenantById = ServerEndPoint + "/tenants/{0}";
            public const string CheckIfNameExist = ServerEndPoint + "/tenants/names";
            public const string GetUsersByTenantId = ServerEndPoint + "/tenants/{0}/users";
            public const string AddTenant = ServerEndPoint + "/tenants";
            public const string AddUserToTenant = ServerEndPoint + "/tenants/{0}/users/{1}";
            public const string RemoveUserFromTenant = ServerEndPoint + "/tenants/{0}/users/{1}";
            public const string DeleteUserTenantById = ServerEndPoint + "/user-tenants/{0}";
            public const string DeleteTenantById = ServerEndPoint + "/tenants/{0}";
            public const string UpdateTenantById = ServerEndPoint + "/tenants/{0}";
            public const string ReplaceTenantUsers = ServerEndPoint + "/tenants/{0}/users";
            public const string CreateDataBase = ServerEndPoint + "/tenants/{0}/ensure-created";
            public const string DeleteDataBase = ServerEndPoint + "/tenants/{0}/ensure-deleted";
            public const string MigrateDataBase = ServerEndPoint + "/tenants/{0}/Migrate";
        }
        public static class AppSettingController
        {
            public const string GetAppSettings = ServerEndPoint + "/app-settings";
            public const string GetAppSettingById = ServerEndPoint + "/app-settings/{0}";
            public const string GetAppSettingByKey = ServerEndPoint + "/app-settings/keys";
            public const string AddAppSetting = ServerEndPoint + "/app-settings";
            public const string DeleteAppSettingById = ServerEndPoint + "/app-settings/{0}";
            public const string DeleteAppSettingByKey = ServerEndPoint + "/app-settings/keys";
            public const string UpdateAppSettingById = ServerEndPoint + "/app-settings/{0}";
        }
        public static class RegionController
        {
            public const string AddNewRegion = ServerEndPoint + "/regions";
            public const string GetRegions = ServerEndPoint + "/regions";
            public const string GetRegion = ServerEndPoint + "/regions/{0}";
            public const string SearchRegions = ServerEndPoint + "/regions/search";//query
            public const string GetParentRegion = ServerEndPoint + "/regions/{0}/parent";
            public const string UpdateRegion = ServerEndPoint + "/regions/{0}";
            public const string DeleteRegion = ServerEndPoint + "/regions/{0}";
            public const string DeleteAllRegions = ServerEndPoint + "/regions/reset";
        }

        #endregion

        #region Tenants EndPoints

        public static class SectionController
        {
            public const string CreateNewSection = TenantEndPoint + "/sections";
            public const string GetSections = TenantEndPoint + "/sections";
            public const string GetSectionById = TenantEndPoint + "/sections/{0}";
            public const string GetParentSection = TenantEndPoint + "/sections/{0}/parent";
            public const string UpdateSectionById = TenantEndPoint + "/sections/{0}";
            public const string DeleteSectionById = TenantEndPoint + "/sections/{0}";
            public const string GetSectionClaims = TenantEndPoint + "/sections/{0}/claims";
            public const string AddSectionClaim = TenantEndPoint + "/sections/{0}/claims";
            public const string UpdateSectionClaims = TenantEndPoint + "/sections/{0}/claims";
            public const string DeleteAllSections = TenantEndPoint + "/sections/reset";
        }
        public static class IntroMethodController
        {
            public const string CreateNewIntroMethod = TenantEndPoint + "/intro-methods";
            public const string GetIntroMethods = TenantEndPoint + "/intro-methods";
            public const string GetIntroMethodById = TenantEndPoint + "/intro-methods/{0}";
            public const string GetParentIntroMethod = TenantEndPoint + "/intro-methods/{0}/parent";
            public const string UpdateIntroMethodById = TenantEndPoint + "/intro-methods/{0}";
            public const string DeleteIntroMethodById = TenantEndPoint + "/intro-methods/{0}";
            public const string DeleteAllIntroMethods = TenantEndPoint + "/intro-methods/reset";
        }
        public static class CaseController
        {
            public const string CreateNewCase = TenantEndPoint + "/cases";
            public const string UpdateCaseById = TenantEndPoint + "/cases/{0}";
            public const string GetCases = TenantEndPoint + "/cases";
            public const string GetCaseById = TenantEndPoint + "/cases/{0}";
            public const string DeleteCaseById = TenantEndPoint + "/cases/{0}";

        }
        public static class VisitController
        {
            //===============================Visits==========================================
            public const string CreateNewVisit = TenantEndPoint + "/visits";
            public const string UpdateVisitById = TenantEndPoint + "/visits/{0}";
            public const string GetVisits = TenantEndPoint + "/visits";
            public const string GetVisitById = TenantEndPoint + "/visits/{0}";
            public const string GetUserByVisitId = TenantEndPoint + "/visits/{0}/user";
            public const string GetVisitByTaskId = TenantEndPoint + "/visits/Tasks/{0}/visit";
            public const string GetUserByTaskId = TenantEndPoint + "/visits/Tasks/{0}/user";
            public const string DeleteVisitById = TenantEndPoint + "/visits/{0}";
            //===========================Tasks=======================================
            public const string GetTasks = TenantEndPoint + "/visits/{0}/tasks";
            public const string GetTaskById = TenantEndPoint + "/visits/tasks/{0}";
            public const string AddTask = TenantEndPoint + "/visits/{0}/tasks/{1}";
            public const string DeleteTask = TenantEndPoint + "/visits/tasks/{0}";
            public const string UpdateTask = TenantEndPoint + "/visits/tasks/{0}";
        }
        public static class DemographicIntakesController
        {
            public const string GetDemographicIntakes = TenantEndPoint + "/intakes/demographics";
            public const string GetDemographicIntakeById = TenantEndPoint + "/intakes/demographics/{0}";
            public const string GetDemographicIntakeByTaskId = TenantEndPoint + "/intakes/demographics/tasks/{0}";
            public const string AddDemographicIntake = TenantEndPoint + "/intakes/demographics";
            public const string CreateDemographicIntake = TenantEndPoint + "/intakes/demographics/new";
            public const string UpdateDemographicIntakeById = TenantEndPoint + "/intakes/demographics/{0}";
            public const string DeleteDemographicIntakeById = TenantEndPoint + "/intakes/demographics/{0}";
        }
        public static class MedicalIntakesController
        {
            public const string GetMedicalIntakes = TenantEndPoint + "/intakes/medicals";
            public const string GetMedicalIntakeById = TenantEndPoint + "/intakes/medicals/{0}";
            public const string GetMedicalIntakeByTaskId = TenantEndPoint + "/intakes/medicals/tasks/{0}";
            public const string AddMedicalIntake = TenantEndPoint + "/intakes/medicals";
            public const string CreateMedicalIntake = TenantEndPoint + "/intakes/medicals/new";
            public const string UpdateMedicalIntakeById = TenantEndPoint + "/intakes/medicals/{0}";
            public const string DeleteMedicalIntakeById = TenantEndPoint + "/intakes/medicals/{0}";
        }

        #endregion








    }
}
