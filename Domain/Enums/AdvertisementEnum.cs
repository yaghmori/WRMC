using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum AdvertisementEnum : short
{
    [Display(Description = "Billboards", Order = 1)] Billboards = 0,
    [Display(Description = "Bus Stop Fillers", Order = 2)] BusStopFillers = 1,
    [Display(Description = "Phone book/Directories", Order = 3)] PhonebookDirectories = 2,
    [Display(Description = "TV Commercial", Order = 4)] TvCommercial = 3,
    [Display(Description = "Radio Advertisement", Order = 5)] RadioAdvertisement = 4,
    [Display(Description = "Flyers", Order = 6)] Flyers = 5,
    [Display(Description = "Newspaper", Order = 7)] Newspaper = 6,
    [Display(Description = "Social Media", Order = 8)] SocialMedia = 7,
}
