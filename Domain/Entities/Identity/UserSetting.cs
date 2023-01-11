using System.ComponentModel.DataAnnotations.Schema;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserSetting : BaseEntity<Guid>
    {


        #region Properties
        public Guid UserId { get; set; }
        public string Theme { get; set; } = string.Empty;
        public bool RightToLeft { get; set; } = false;
        public bool DarkMode { get; set; } = false;
        public string Culture { get; set; } = "en-US";
        public virtual User User { get; set; }



        #endregion



    }
}
