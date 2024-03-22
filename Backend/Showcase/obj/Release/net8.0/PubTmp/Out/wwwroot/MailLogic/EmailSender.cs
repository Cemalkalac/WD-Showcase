namespace Showcase.wwwroot.MailLogic
{
    public interface EmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
