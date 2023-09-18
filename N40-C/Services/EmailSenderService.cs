using System.Net.NetworkInformation;

namespace N40_C.Services;

public class EmailSenderService
{
    public ValueTask SendEmailAsync(string emailAddress, string subject, string body)
    {
        var networkException = new NetworkInformationException(404);
        throw new InvalidOperationException("Email server settings are invalid", networkException);
    }
}