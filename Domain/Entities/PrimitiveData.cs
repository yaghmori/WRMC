using System.ComponentModel.DataAnnotations.Schema;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.Domain.Entities
{


    public class PrimitiveData : BaseEntity<Guid>
    {
        [Column(Order = 2)]
        public Guid? ParentId { get; set; }
        public virtual Section? Parent { get; set; }
        [Column(Order = 3)]
        public string Name { get; set; } = default!;
        [Column(Order = 4)]
        public string? DisplayTitle { get; set; } = default!;
        [Column(Order = 5)]
        public int Order { get; set; } = default!;
        [Column(Order = 6)]
        public bool IsRequired { get; set; } = default!;
        [Column(Order = 7)]
        public string Value { get; set; } = default!;
    }
}
