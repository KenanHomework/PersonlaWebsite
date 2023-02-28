using MimeKit;

namespace PersonlaWebsite.Models
{
    public class Message
    {
        public MailboxAddress To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Message(string name, string to, string subject, string content)
        {
            To = new MailboxAddress(name, to);
            Subject = subject;
            Content = content;
        }
    }
}
