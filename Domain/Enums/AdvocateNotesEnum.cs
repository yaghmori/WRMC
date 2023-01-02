using System.ComponentModel.DataAnnotations;

namespace WRMC.Infrastructure.Domain.Enums;

public enum AdvocateNotesEnum : short
{
    [Display(Description = "Positive Test Result - No Vulnerabilities", Order = 1)] PositiveNoVulnerabilities = 0,
    [Display(Description = "Positive Test Result - Vulnerabilities", Order = 2)] PositiveVulnerabilities = 1,
    [Display(Description = "Negative Test Result - No Vulnerabilities", Order = 3)] NegativeNoVulnerabilities = 2,
    [Display(Description = "Negative Test Result - Vulnerabilities", Order = 4)] NegativeVulnerabilities = 3,
    [Display(Description = "Conversation accurately supports written documentation by client", Order = 5)] SupportsWrittenDocumentation = 4,
    [Display(Description = "Conversation does not accurately supports written documentation by client", Order = 6)] DoesNotSupportsWrittenDocumentation = 5,
    [Display(Description = "Needs additional counseling - client denied", Order = 7)] NeedsAdditionalCounselingClientDenied = 6,
    [Display(Description = "Needs additional counseling - client agreed", Order = 8)] NeedsAdditionalCounselingClientAgreed = 7,
    [Display(Description = "Gospel Presented - Received-Profession of Faith/Rededication", Order = 9)] GospelPresentedReceivedProfessionFaithRededication = 8,
    [Display(Description = "Gospel Presented - No profession of Faith made", Order = 10)] GospelPresentedNoProfessionFaithMade = 9,
    [Display(Description = "Offered Prayer - Accepted", Order = 11)] OfferedPrayerAccepted = 10,
    [Display(Description = "Offered Prayer - Client Refused", Order = 12)] OfferedPrayerClientRefused = 11,
    [Display(Description = "Clear Communication with Client", Order = 13)] ClearCommunicationWithClient = 12,
    [Display(Description = "Poor Communication - Language/Literacy barrier", Order = 14)] PoorCommunicationLanguageLiteracyBarrier = 13,
    [Display(Description = "Poor Communication - Client not coherent", Order = 15)] PoorCommunicationClientNotCoherent = 14,
    [Display(Description = "Due to conversation adjustment to Vulnerability Assessment needed", Order = 16)] AdjustmentToVulnerabilityAssessmentNeeded = 15,
    [Display(Description = "Translator assistance helpful", Order = 17)] TranslatorAssistanceHelpful = 16,
    [Display(Description = "Translator assistance not helpful", Order = 18)] TranslatorAssistanceNotHelpful = 17,
    [Display(Description = "Personal Advocate Assessment ABV - No Change to Flags", Order = 19)] PersonalAdvocateAssessmentAbvNoChangeToFlags = 18,
    [Display(Description = "Personal Advocate Assessment ABM - No Change to Flags", Order = 20)] PersonalAdvocateAssessmentAbmNoChangeToFlags = 19,
    [Display(Description = "Personal Advocate Assessment ABV - Request Change to Flags", Order = 21)] PersonalAdvocateAssessmentAbvRequestChangeToFlags = 20,
    [Display(Description = "Personal Advocate Assessment ABM - Request Change to Flags", Order = 22)] PersonalAdvocateAssessmentAbmRequestChangeToFlags = 21,
    [Display(Description = "Report to authorities Required", Order = 23)] ReportToAuthoritiesRequired = 22,
}
