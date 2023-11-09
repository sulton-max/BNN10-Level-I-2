using N64.Identity.Domain.Entities;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IAccessTokenService
{
    ValueTask<AccessToken> CreateAsync(
        Guid userId, 
        string value,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );
}