using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Domain.Enums;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IAuthService
{
    ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails, CancellationToken cancellationToken = default);

    ValueTask<string> LoginAsync(LoginDetails loginDetails, CancellationToken cancellationToken = default);

    ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, Guid actionUserId, CancellationToken cancellationToken = default);
}