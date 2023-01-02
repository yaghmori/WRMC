using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum UltrasoundScheduledTypeEnum : short
{
    [Display(Description = "Same Day Appointment (Please expect a 2-hour wait time)", Order = 1)] SameDayAppointment = 0,
    [Display(Description = "Next Available", Order = 2)] NextAvailable = 1,
    [Display(Description = "Specific Time Slot Requested", Order = 3)] SpecificTimeSlotRequested = 2,
}
