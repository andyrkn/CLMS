using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CLMS.Notification.Domain;
using EnsureThat;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CLMS.Notification.Email
{
    public class EmailService : IEmailService
    {
        private readonly SendGridClient client;

        public EmailService(EmailOptions options)
        {
            EnsureArg.IsNotNull(options);
            EnsureArg.IsNotNullOrWhiteSpace(options.ApiKey);

            client = new SendGridClient(options.ApiKey);
        }

        public async Task Send(EmailMessage message)
        {
            var from = new EmailAddress("notification@clms.com", "Support");
            var to = new EmailAddress(message.To);
            var plainTextContent = Regex.Replace(message.Body, "<[^>]*>", "");
            var msg = MailHelper.CreateSingleEmail(from, to, message.Subject, plainTextContent, message.Body);

            await client.SendEmailAsync(msg);
        }
    }
}