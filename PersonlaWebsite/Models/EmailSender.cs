using MailKit.Net.Smtp;
using MimeKit;
using PersonlaWebsite.Configurations;
using PersonlaWebsite.Interfaces;

namespace PersonlaWebsite.Models
{
    public class EmailSender : IEmailSender
    {

        private readonly EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmail(Message message)
        {
            MimeMessage emailMessage;
            if (message.Subject == "Thank For Contact Me")
            {
                emailMessage = CreateThankContactEmailMessage(message);
                Send(emailMessage);
            }
            else
            {
                emailMessage = CreateEmailMessage(message);
                Send(emailMessage);
            }
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Kanan", _emailConfig.From));
            emailMessage.To.Add(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        private MimeMessage CreateThankContactEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Kanan", _emailConfig.From));
            emailMessage.To.Add(message.To);
            emailMessage.Subject = message.Subject;

            string emailTemplate = File.ReadAllText(@"wwwroot\EmailTemplates\ThankContactMe.html");
            emailTemplate = emailTemplate.Replace("[username]", message.To.Name);
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailTemplate };

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
                    client.Send(mailMessage);
                }
                catch { }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
