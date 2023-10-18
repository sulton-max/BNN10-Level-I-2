using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using N58_C.Models.Settings;

namespace N58_C.Service;

// INotificationService

// EmailSenderService
// SmsSenderService

// Array - Array<int>

public class EmailSenderService
{
    private readonly EmailSenderSettings _settings;

    // IOptionsSnapshot<EmailSenderSettings> - EmailSenderSettings
    // IOptionsSnapshot<EmailSenderSettings> - IOptions<EmailSenderSettings>

    public EmailSenderService(IOptions<EmailSenderSettings> settings)
    {
        _settings = settings.Value;
    }

    public void SendEmail(string to, string userName)
    {
        var mail = new MailMessage(_settings.CredentialAddress, to);
        mail.Subject = "Siz muvaffaqiyatli registratsiyadan o'tdingiz";
        mail.Body = "Hurmatli {{User}}, siz sistemadan muvaffaqiyatli o'tdingiz".Replace("{{User}}", userName);

        var smtpClient = new SmtpClient(_settings.Host, _settings.Port); // Replace with your SMTP server address and port
        smtpClient.Credentials = new NetworkCredential(_settings.CredentialAddress, _settings.Password);
        smtpClient.EnableSsl = true;

        smtpClient.Send(mail);
    }
}