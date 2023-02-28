using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonlaWebsite.Interfaces;
using PersonlaWebsite.Models;

namespace PersonlaWebsite.Pages
{
    public class ContactModel : PageModel
    {

        private IEmailSender _emailSender;

        public ContactModel(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void OnGet()
        {
        }

        public void OnPost(User user)
        {
            var message = new Message(user.Name, user.Email, "Thank For Contact Me", "");
            _emailSender.SendEmail(message);
        }
    }
}
