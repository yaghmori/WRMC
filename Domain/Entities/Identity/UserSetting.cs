using System.ComponentModel.DataAnnotations.Schema;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserSetting : BaseEntity<Guid>
    {


        #region Properties
        [Column(Order = 1)]
        public Guid UserId { get; set; }
        [Column(Order = 2)]
        public string Theme { get; set; } = string.Empty;
        [Column(Order = 3)]
        public bool RightToLeft { get; set; } = false;
        [Column(Order = 4)]
        public bool DarkMode { get; set; } = false;
        [Column(Order = 5)]
        public string Culture { get; set; } = "en-US";
        public virtual User User { get; set; }



        #endregion



    }
}
