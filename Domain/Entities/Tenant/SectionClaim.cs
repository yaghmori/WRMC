using System.ComponentModel.DataAnnotations.Schema;

namespace WRMC.Infrastructure.Domain.Entities;

public class SectionClaim : BaseEntity<Guid>
{
    [Column(Order = 2)]
    public Guid SectionId { get; set; }
    public virtual Section Section { get; set; }
    [Column(Order = 3)]
   public string ClaimType { get; set;}
    [Column(Order = 4)]
   public string ClaimValue { get; set;}
}