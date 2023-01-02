using WRMC.Infrastructure.Domain.Entities;

namespace WRMC.Infrastructure.DataAccess.Context
{
    static partial class Seed
    {
        internal static List<Culture> Cultures = new List<Culture> {
            new Culture {Id= Guid.NewGuid(),CultureName= "en-US",  DisplayName="English",ShortDatePattern="yyyy/MM/dd",LongDatePattern="dddd, MMMM dd, yyyy",LongTimePattern="HH:mm:ss",ShortTimePattern="HH:mm",FullDateTimePattern="dddd, MMMM dd, yyyy h:mm:ss tt",DateSeparator="/",TimeSeparator=":",YearMonthPattern="MMMM, yyyy",MonthDayPattern="MMMM dd",FirstDayOfWeek=DayOfWeek.Monday,Image="_content/wrmc.RootComponents/assets/media/flags/usa.svg",IsDefault=true,RightToLeft=false },
            new Culture {Id= Guid.NewGuid(),CultureName= "fa-IR",DisplayName="فارسی",ShortDatePattern="yyyy/MM/dd",LongDatePattern="dddd, MMMM dd, yyyy ",LongTimePattern="HH:mm:ss",ShortTimePattern="HH:mm",FullDateTimePattern="dddd, MMMM dd, yyyy h:mm:ss tt",DateSeparator="/",TimeSeparator=":",YearMonthPattern="MMMM, yyyy",MonthDayPattern="MMMM dd",FirstDayOfWeek=DayOfWeek.Saturday,Image="_content/wrmc.RootComponents/assets/media/flags/iran.svg",IsDefault=false,RightToLeft=true }
        };
    };
}

