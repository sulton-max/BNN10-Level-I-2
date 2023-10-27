using Microsoft.AspNetCore.DataProtection;
using N65.VerificationCode.Models;
using Newtonsoft.Json;

namespace N65.VerificationCode.Services;

public class VerificationTokenGeneratorService
{
    private readonly IDataProtector _protecter;

    public VerificationTokenGeneratorService(IDataProtectionProvider provider)
    {
        _protecter = provider.CreateProtector("VerificationTokenGeneratorService");
    }

    public string Generate(Guid userId, VerificationType type, DateTimeOffset expirationTime)
    {
        var verificationToken = new VerificationToken
        {
            UserId = userId,
            ExpireTime = DateTimeOffset.UtcNow.AddMinutes(5),
            Type = type
        };

        return _protecter.Protect(JsonConvert.SerializeObject(verificationToken));
    }

    public VerificationToken Decrypt(string verificationToken)
    {
        var unprotectedModel = _protecter.Unprotect(verificationToken);
        var model = JsonConvert.DeserializeObject<VerificationToken>(unprotectedModel) ??
                    throw new InvalidOperationException("Verification token is invalid.");

        return model;
    }
}