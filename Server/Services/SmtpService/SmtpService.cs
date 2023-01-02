using MimeKit;
using MimeKit.Text;
using WRMC.Core.Shared.Helpers;

namespace WRMC.Server.Services
{
    public class SmtpService : ISmtpService
    {
        private string _username;
        private string _passsword;
        private string _host;
        private int _port;
        public SmtpService()
        {
            _host = ConfigHelper.SmtpSettings.Host;
            _username = ConfigHelper.SmtpSettings.Username;
            _passsword = ConfigHelper.SmtpSettings.Password;
            _port = ConfigHelper.SmtpSettings.Port;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_username));
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = message };

                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                {
                    await smtp.ConnectAsync(_host, _port, MailKit.Security.SecureSocketOptions.StartTls);
                    await smtp.AuthenticateAsync(_username, _passsword);
                    await smtp.SendAsync(email);
                    await smtp.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}

