using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Showcase.wwwroot.MailLogic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;



namespace Showcase.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string email, string subject, string message)
        {
            // Validate email format, subject length, and message length
            if (!IsValidEmail(email))
            {
                ModelState.AddModelError("email", "Invalid email format.");
            }

            if (subject.Length > 200)
            {
                ModelState.AddModelError("subject", "Subject cannot exceed 200 characters.");
            }

            if (message.Length > 600)
            {
                ModelState.AddModelError("message", "Message cannot exceed 600 characters.");
            }


            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = "Email has not successfully sent.";
                return View("Index");
            }


            // If validation passes, proceed with sending email

            var mailSender = new Mail();
            await mailSender.SendEmailAsync(email, subject, message);
            TempData["AlertMessage"] = "Email has been successfully sent.";
            return RedirectToAction("Index", "Contact");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}


    

