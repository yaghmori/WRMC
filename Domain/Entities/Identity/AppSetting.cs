using System.ComponentModel.DataAnnotations.Schema;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class AppSetting : BaseEntity<Guid>
    {


        #region Properties
        public string Key { get; set; }=default!;
        public string Value { get; set; }= default!;
        public string? Description { get; set; }    = default!;
        public bool? IsReadOnly { get; set; } = default!;


        #endregion



    }
}
