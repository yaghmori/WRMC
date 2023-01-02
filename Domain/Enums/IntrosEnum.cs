using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum IntrosEnum : short
{
    [Display(Description = "Advertisement", Order = 1)] Advertisement = 0,
    [Display(Description = "Friends/Relatives/Partner", Order = 2)] FriendsRelativesPartner = 1,
    [Display(Description = "Repeat Client", Order = 3)] RepeatClient = 2,
    [Display(Description = "Walk-in/Passer By", Order = 4)] WalkInPasserBy = 3,
    [Display(Description = "Crisis Pregnancy Centers", Order = 5)] CrisisPregnancyCenters = 4,
    [Display(Description = "Option United", Order = 6)] OptionUnited = 5,
    [Display(Description = "Community Event", Order = 7)] CommunityEvent = 6,
    [Display(Description = "Church Event", Order = 8)] ChurchEvent = 7,
    [Display(Description = "Baby First Services", Order = 9)] BabyFirstServices = 8,
    [Display(Description = "Medical Referrals", Order = 10)] MedicalReferrals = 9,
    [Display(Description = "Government Agencies", Order = 11)] GovernmentAgencies = 10,
    [Display(Description = "Alcohol/Drug Rehabs", Order = 12)] AlcoholDrugRehabs = 11,
    [Display(Description = "Shelters", Order = 13)] Shelters = 12,
    [Display(Description = "Church Referral", Order = 14)] ChurchReferral = 13,
    [Display(Description = "Abortion Clinic", Order = 15)] AbortionClinic = 14,
    [Display(Description = "Help of Southern Nevada", Order = 16)] HelpOfSouthernNevada = 15,
}
