namespace WRMC.Server.Services
{
    public interface ISmtpService
    {
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false);
    }
}
