using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace WRMC.Infrastructure.Domain.Entities
{
    public class Culture : BaseEntity<Guid>
    {
        [Column(Order = 2)]
        public string CultureName { get; set; } = "en-US";
        [Column(Order = 3)]
        public string DisplayName { get; set; } = "English";
        [Column(Order = 4)]
        public string ShortDatePattern { get; set; } = "yyyy/MM/dd";
        [Column(Order = 5)]
        public string LongDatePattern { get; set; } = "dddd, MMMM dd, yyyy";
        [Column(Order = 6)]
        public string LongTimePattern { get; set; } = "HH:mm:ss";
        [Column(Order = 7)]
        public string ShortTimePattern { get; set; } = "HH:mm";
        [Column(Order = 8)]
        public string FullDateTimePattern { get; set; } = "dddd, MMMM dd, yyyy h:mm:ss tt";
        [Column(Order = 9)]
        public string DateSeparator { get; set; } = "/";
        [Column(Order = 10)]
        public string TimeSeparator { get; set; } = ":";
        [Column(Order = 11)]
        public string YearMonthPattern { get; set; } = "MMMM, yyyy";
        [Column(Order = 12)]
        public string MonthDayPattern { get; set; } = "MMMM dd";
        [Column(Order = 13)]
        public DayOfWeek FirstDayOfWeek { get; set; } = DayOfWeek.Monday;
        [Column(Order = 14)]
        public string Image { get; set; } = "";
        [Column(Order = 15)]
        public bool IsDefault { get; set; } = false;
        [Column(Order = 16)]
        public bool RightToLeft { get; set; } = false;

        [NotMapped]
        public CultureInfo CultureInfo { get { return new CultureInfo(CultureName); } }
    }
}
