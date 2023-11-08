using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Domain.Enums;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails);

    ValueTask<string> LoginAsync(LoginDetails loginDetails);

    ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, Guid actionUserId);
}