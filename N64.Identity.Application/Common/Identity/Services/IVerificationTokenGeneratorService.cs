using N64.Identity.Application.Common.Enums;
using N64.Identity.Application.Common.Identity.Models;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IVerificationTokenGeneratorService
{
    string GenerateToken(VerificationType type, Guid userId);

    (VerificationToken Token, bool IsValid) DecodeToken(string token);
}