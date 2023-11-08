using N64.Identity.Domain.Entities;
using N64.Identity.Persistence.DataContexts;
using N64.Identity.Persistence.Repositories.Interfaces;

namespace N64.Identity.Persistence.Repositories;

public class UserRepository : EntityRepositoryBase<User>, IUserRepository
{
    public UserRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }

    public ValueTask<User?> GetByIdAsync(Guid userId)
    {
        return base.GetByIdAsync(userId);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChangesAsync, CancellationToken cancellationToken)
    {
        return base.UpdateAsync(user, saveChangesAsync, cancellationToken);
    }
}