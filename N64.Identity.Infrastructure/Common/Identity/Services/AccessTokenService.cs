using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Domain.Entities;
using N64.Identity.Persistence.Repositories.Interfaces;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class AccessTokenService : IAccessTokenService
{
    private readonly IAccessTokenRepository _accessTokenRepository;

    public AccessTokenService(IAccessTokenRepository accessTokenRepository)
    {
        _accessTokenRepository = accessTokenRepository;
    }

    public ValueTask<AccessToken> CreateAsync(
        AccessToken token,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        return _accessTokenRepository.CreateAsync(token, saveChanges, cancellationToken);
    }

    public async ValueTask<AccessToken> CreateAsync(
        Guid userId,
        string value,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    )
    {
        var accessToken = new AccessToken
        {
            UserId = userId,
            Value = value,
            CreatedTime = DateTime.UtcNow
        };

        await _accessTokenRepository.CreateAsync(accessToken, saveChanges, cancellationToken);

        return accessToken;
    }
}