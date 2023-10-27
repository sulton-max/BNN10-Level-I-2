namespace N65.VerificationCode.Services;

public class VerificationCodeGeneratorService
{
    // api/accounts/:accountId/email/verification post userId verificationCode
    // api/accounts/:accountId/phoneNumber/verification post userId verificationCode

    // Id
    // UserId
    // VerificationCode
    // ExpirationTime - DateTimeOffset
    // VerificationCodeType

    public string Generate => new Random().Next(100000, 999999).ToString();
}