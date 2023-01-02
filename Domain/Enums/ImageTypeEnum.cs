using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum AttachmentTypeEnum : short
{
    [Display(Description = "None", AutoGenerateField =false, Order = 0)]
    None = 0,
    [Display(Description = "Identification Card", ShortName = "id-card", Order = 1)]
    IdCard = 1,
    [Display(Description = "Driver License", ShortName = "id-badge", Order = 2)]
    DriverLicense = 2,
    [Display(Description = "Passport", ShortName = "passport", Order = 3)]
    Passport = 3,
    [Display(Description = "Full-Face Photo", ShortName = "circle-user", Order = 4)]
    FullFacePhoto = 4,
    [Display(Description = "Residence Image ", ShortName = "file-lines", Order = 5)]
    ResidenceImage = 5,
    [Display(Description = "Signature", ShortName = "signature", Order = 6)]
    Signature = 6,
    [Display(Description = "Other", ShortName = "file", Order = 1000)]
    Other = 1000,
}