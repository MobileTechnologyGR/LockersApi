using LockersService.Model;
using LockersService.Models;

namespace LockersService.Interfaces
{
    public interface IEmailSender
    {

        Task<string> SendEmailAsync0(string recipientEmail, string recipientFirstName, string Link, SmtpSettings smtpSettings, CsLockersTransaction lockersTransaction);
        Task<string> SendEmailAsync1(string recipientEmail, string recipientFirstName, string Link, SmtpSettings smtpSettings, CsLockersTransaction lockersTransaction);
        Task<string> SendEmailAsync3(string recipientEmail, string recipientFirstName, string Link, SmtpSettings smtpSettings, CsLockersTransaction lockersTransaction);
        Task<string> SendEmailAsync4(string recipientEmail, string recipientFirstName, string Link, SmtpSettings smtpSettings, CsLockersTransaction lockersTransaction);
        Task<string> SendEmailAsync5(string recipientEmail, string recipientFirstName, string Link, SmtpSettings smtpSettings, CsLockersTransaction lockersTransaction);
        Task<string> SendEmailAsync6(string recipientEmail, string recipientFirstName, string Link, SmtpSettings smtpSettings, CsLockersTransaction lockersTransaction);

    }
}
