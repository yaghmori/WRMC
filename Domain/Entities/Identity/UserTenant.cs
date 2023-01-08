using System.ComponentModel.DataAnnotations.Schema;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class UserTenant : BaseEntity<Guid>
    {

      





        #region Properties
        [Column(Order = 1)]
        public Guid UserId { get; set; }
        [Column(Order = 2)]
        public Guid TenantId { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual User User { get; set; }


        #endregion

    }

}
