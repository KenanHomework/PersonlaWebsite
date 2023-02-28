using PersonlaWebsite.Models;

namespace PersonlaWebsite.Interfaces;

public interface IEmailSender
{
    void SendEmail(Message message);
}
