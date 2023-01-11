using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace WRMC.Core.Shared.Requests
{
    public class CultureRequest
    {
        public string CultureName { get; set; } = "en-US";

        public string DisplayName { get; set; } = "English";

        public string ShortDatePattern { get; set; } = "yyyy/MM/dd";

        public string LongDatePattern { get; set; } = "dddd, MMMM dd, yyyy";

        public string LongTimePattern { get; set; } = "HH:mm:ss";

        public string ShortTimePattern { get; set; } = "HH:mm";

        public string FullDateTimePattern { get; set; } = "dddd, MMMM dd, yyyy h:mm:ss tt";

        public string DateSeparator { get; set; } = "/";

        public string TimeSeparator { get; set; } = ":";

        public string YearMonthPattern { get; set; } = "MMMM, yyyy";

        public string MonthDayPattern { get; set; } = "MMMM dd";

        public DayOfWeek FirstDayOfWeek { get; set; } = DayOfWeek.Monday;

        public string Image { get; set; } = "";

        public bool IsDefault { get; set; } = false;
        public bool RightToLeft { get; set; } = false;
        public string NormalizedCultureName => CultureName.Normalize();
        public string NormalizedDisplayName => DisplayName.Normalize();

        [NotMapped]
        public CultureInfo CultureInfo { get { return new CultureInfo(CultureName); } }
    }
}
