namespace WRMC.Core.Shared.Requests
{
    public class UserRoleRequest
    {
        #region Constructor


        public UserRoleRequest(string userId, IList<string> roles)
        {
            UserId = userId;
            Roles = roles;
        }


        #endregion



        public string UserId { get; set; }

        public IList<string> Roles { get; set; } = new List<string>();
    }


}
