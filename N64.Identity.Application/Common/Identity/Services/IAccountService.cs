using N64.Identity.Domain.Entities;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<bool> VerificateAsync(string token, CancellationToken cancellationToken = default);

    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
}