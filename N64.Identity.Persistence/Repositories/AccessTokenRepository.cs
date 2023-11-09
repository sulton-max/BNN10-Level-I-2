using Microsoft.EntityFrameworkCore;
using N64.Identity.Domain.Entities;
using N64.Identity.Persistence.DataContexts;
using N64.Identity.Persistence.Repositories.Interfaces;

namespace N64.Identity.Persistence.Repositories;

public class AccessTokenRepository : EntityRepositoryBase<AccessToken, IdentityDbContext>, IAccessTokenRepository
{
    public AccessTokenRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }
    
    public ValueTask<AccessToken> CreateAsync(AccessToken token, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(token, saveChanges, cancellationToken);
    }
}