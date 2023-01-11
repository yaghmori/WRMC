using System.Reflection;

namespace WRMC.Core.Shared.Constants;

public static class AppPermissions
{
    public static class Global
    {
        public const string Availability = "Global.Availability";
        public const string Correction = "Global.Correction";
        public const string Lot = "Global.Lot";
        public const string Notice = "Global.Notice";
        public const string Permission = "Global.Permission";
        public const string Queue = "Global.Queue";
        public const string Role = "Global.Role";
        public const string Room = "Global.Room";
        public const string Setting = "Global.Setting";
        public const string Slider = "Global.Slider";
        public const string Staff = "Global.Staff";
        public const string Tasks = "Global.Tasks";
        public const string UserRole = "Global.UserRole";
        public const string VisitTermination = "Global.VisitTermination";
        public const string AppointmentBehalf = "Global.AppointmentBehalf";
        public const string CheckIn = "Global.CheckIn";
        public const string Checkout = "Global.Checkout";
        public const string Connection = "Global.Connection";
        public const string Explorer = "Global.Explorer";
        public const string RegisterBehalf = "Global.RegisterBehalf";
        public const string Delayed = "Global.Delayed";
        public const string CaseReview = "Global.CaseReview";
    }

    public static class PregnancyTest
    {
        public const string Initial = "PregnancyTest.Initial";
        public const string Medical = "PregnancyTest.Medical";
        public const string Demographic = "PregnancyTest.Demographic";
        public const string Required = "PregnancyTest.Required";
        public const string Appointment = "PregnancyTest.Appointment";
        public const string Social = "PregnancyTest.Social";
        public const string SocialReview = "PregnancyTest.SocialReview";
        public const string Decision = "PregnancyTest.Decision";
        public const string ExitSurvey = "PregnancyTest.ExitSurvey";
        public const string QaAssignment = "PregnancyTest.QaAssignment";
        public const string PaAssignment = "PregnancyTest.PaAssignment";
        public const string RequestList = "PregnancyTest.RequestList";
        public const string Vulnerability = "PregnancyTest.Vulnerability";
        public const string Spiritual = "PregnancyTest.Spiritual";
        public const string TestResult = "PregnancyTest.TestResult";
    }

    public static class PregnancyRetest
    {
        public const string Medical = "PregnancyRetest.Medical";
        public const string Appointment = "PregnancyRetest.Appointment";
        public const string Social = "PregnancyRetest.Social";
        public const string Decision = "PregnancyRetest.Decision";
        public const string Exit = "PregnancyRetest.Exit";
        public const string Assignment = "PregnancyRetest.Assignment";
        public const string RequestList = "PregnancyRetest.RequestList";
        public const string Vulnerability = "PregnancyRetest.Vulnerability";
        public const string Spiritual = "PregnancyRetest.Spiritual";
        public const string TestResult = "PregnancyRetest.TestResult";


    }

    public static class UltrasoundScan
    {
        public const string Interview = "UltrasoundScan.Interview";
        public const string Appointment = "UltrasoundScan.Appointment";
        public const string UExit = "UltrasoundScan.UExit";
        public const string Assignment = "UltrasoundScan.Assignment";
        public const string RequestList = "UltrasoundScan.RequestList";
        public const string UltrasoundReport = "UltrasoundScan.UltrasoundReport";

    }

    public static class UltrasoundRescan
    {
        public const string Interview = "UltrasoundRescan.Interview";
        public const string Appointment = "UltrasoundRescan.Appointment";
        public const string UExit = "UltrasoundRescan.UExit";
        public const string Assignment = "UltrasoundRescan.Assignment";
        public const string RequestList = "UltrasoundRescan.RequestList";
        public const string UltrasoundReport = "UltrasoundRescan.UltrasoundReport";

    }

    public static class PregnancyOptionsCounseling
    {
        public const string Initial = "PregnancyOptionsCounseling.Initial";
        public const string Demographic = "PregnancyOptionsCounseling.Demographic";
        public const string Medical = "PregnancyOptionsCounseling.medical";
        public const string Required = "PregnancyOptionsCounseling.Required";
        public const string Appointment = "PregnancyOptionsCounseling.appointment";
        public const string Exit = "PregnancyOptionsCounseling.exit";
        public const string Assignment = "PregnancyOptionsCounseling.assignment";
        public const string Information = "PregnancyOptionsCounseling.information";
        public const string RequestList = "PregnancyOptionsCounseling.requestlist";

    }

    public static class PostAbortionCounseling
    {
        public const string Initial = "PostAbortionCounseling.Initial";
        public const string Demographic = "PostAbortionCounseling.Demographic";
        public const string Medical = "PostAbortionCounseling.Medical";
        public const string Required = "PostAbortionCounseling.Required";
        public const string Appointment = "PostAbortionCounseling.Appointment";
        public const string Exit = "PostAbortionCounseling.Exit";
        public const string Assignment = "PostAbortionCounseling.Assignment";
        public const string Information = "PostAbortionCounseling.Information";
        public const string RequestList = "PostAbortionCounseling.RequestList";

    }

    public static class PregnancyLossCounseling
    {
        public const string Initial = "PregnancyLossCounseling.Initial";
        public const string Demographic = "PregnancyLossCounseling.Demographic";
        public const string Medical = "PregnancyLossCounseling.Medical";
        public const string Required = "PregnancyLossCounseling.Required";
        public const string Appointment = "PregnancyLossCounseling.Appointment";
        public const string Exit = "PregnancyLossCounseling.Exit";
        public const string Assignment = "PregnancyLossCounseling.Assignment";
        public const string Information = "PregnancyLossCounseling.Information";
        public const string RequestList = "PregnancyLossCounseling.RequestList";

    }

    public static class DiscipleshipCounseling
    {
        public const string Initial = "DiscipleshipCounseling.Initial";
        public const string Demographic = "DiscipleshipCounseling.Demographic";
        public const string Medical = "DiscipleshipCounseling.Medical";
        public const string Required = "DiscipleshipCounseling.Required";
        public const string Appointment = "DiscipleshipCounseling.Appointment";
        public const string Exit = "DiscipleshipCounseling.Exit";
        public const string Assignment = "DiscipleshipCounseling.Assignment";
        public const string Information = "DiscipleshipCounseling.Information";
        public const string RequestList = "DiscipleshipCounseling.RequestList";

    }

    public static class PrenatalCareInterview
    {
        public const string Pregnancy = "PrenatalCareInterview.Pregnancy";
        public const string MedicalHistory = "PrenatalCareInterview.MedicalHistory";
        public const string SupportAssessment = "PrenatalCareInterview.SupportAssessment";
        public const string Residence = "clien.prenatalcareinterviewt.Residence";
        public const string CarrierScreening = "PrenatalCareInterview.CarrierScreening";
        public const string Appointment = "PrenatalCareInterview.Appointment";
        public const string Assignment = "PrenatalCareInterview.Assignment";
        public const string RequestList = "PrenatalCareInterview.RequestList";

    }

    public static class PrenatalVisits
    {
        public const string Appointment = "PrenatalVisits.Appointment";
        public const string Exit = "PrenatalVisits.Exit";
        public const string Assignment = "PrenatalVisits.Assignment";
        public const string Prenatal = "PrenatalVisits.Prenatal";
        public const string RequestList = "PrenatalVisits.RequestList";
        public const string Record = "PrenatalVisits.Record";
        public const string Laboratory = "PrenatalVisits.Laboratory";

    }

    public static class MaleCounseling
    {
        public const string Initial = "MaleCounseling.Initial";
        public const string Demographic = "MaleCounseling.Demographic";
        public const string MaleMedical = "MaleCounseling.Malemedical";
        public const string Required = "MaleCounseling.Required";
        public const string Appointment = "MaleCounseling.Appointment";
        public const string Exit = "MaleCounseling.Exit";
        public const string MaleAssignment = "MaleCounseling.MaleAssignment";
        public const string Medical = "MaleCounseling.Medical";
        public const string MaleInformation = "MaleCounseling.MaleInformation";
    }


    /// <summary>
    /// Returns a list of Permissions.
    /// </summary>
    /// <returns></returns>
    public static List<string> GetPermissions()
    {
        var permissions = new List<string>();
        foreach (var prop in typeof(AppPermissions).GetNestedTypes().SelectMany(c => c.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)))
        {
            var propertyValue = prop.GetValue(null);
            if (propertyValue is not null)
                permissions.Add(propertyValue.ToString());
        }
        return permissions;
    }
}
