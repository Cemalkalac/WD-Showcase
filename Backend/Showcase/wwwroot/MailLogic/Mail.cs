using System.Net;
using System.Net.Mail;

namespace Showcase.wwwroot.MailLogic
{
    public class Mail : EmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("mail.jochemtv.nl", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("cemal@jochemtv.nl", "kosdik-Dirzec-1disnu")
            };

            await client.SendMailAsync(
                new MailMessage(from: email,
                    to: "cemal@jochemtv.nl",
                    subject,
                    message
                ));
        }
    }
}
