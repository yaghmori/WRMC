using System.ComponentModel.DataAnnotations.Schema;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class AppSetting : BaseEntity<Guid>
    {


        #region Properties
        [Column(Order = 2)]
        public string Key { get; set; }=default!;
        [Column(Order = 3)]
        public string Value { get; set; }= default!;
        [Column(Order = 4)]
        public string? Description { get; set; }    = default!;
        [Column(Order = 5)]
        public bool? IsReadOnly { get; set; } = default!;


        #endregion



    }
}
