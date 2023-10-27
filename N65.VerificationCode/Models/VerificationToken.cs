namespace N65.VerificationCode.Models;

public enum VerificationType
{
    Email,
    PhoneNumber
}

public class VerificationToken
{
    public Guid UserId { get; set; }

    public DateTimeOffset ExpireTime { get; set; }

    public VerificationType Type { get; set; }
}