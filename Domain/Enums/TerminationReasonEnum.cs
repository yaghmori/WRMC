using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum TerminationReasonEnum : short
{
    [Display(Description = "Patient Experiencing Bleeding", Order = 1)] PatientExperiencingBleeding = 0,
    [Display(Description = "Patient Vital Measurements", Order = 2)] PatientVitalMeasurements = 1,
    [Display(Description = "Family/Partner", Order = 4)] FamilyPartner = 2,
    [Display(Description = "Expected an Abortion Only", Order = 5)] ExpectedAbortionOnly = 3,
    [Display(Description = "Expected an Ultrasound Only", Order = 6)] ExpectedUltrasoundOnly = 4,
    [Display(Description = "Wait Time", Order = 7)] WaitTime = 5,
    [Display(Description = "Offended by Personnel/Religious Affiliation", Order = 8)] OffendedbyPersonnelReligiousAffiliation = 6,
    [Display(Description = "Internet/Phone Line Issues", Order = 9)] InternetPhoneLineIssues = 7,
    [Display(Description = "Software Issues", Order = 10)] SoftwareIssues = 8,
    [Display(Description = "Natural Disasters", Order = 11)] NaturalDisasters = 9,
    [Display(Description = "Unexpected clinic Closure", Order = 12)] UnexpectedClinicClosure = 10,
    [Display(Description = "Patient Asked to Leave", Order = 13)] PatientAskedLeave = 11,
    [Display(Description = "Paitient Miscarried", Order = 3)] PaitientMiscarried = 12,
}
