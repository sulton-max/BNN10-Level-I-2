using N64.Identity.Domain.Entities;

namespace N64.Identity.Persistence.Repositories.Interfaces;

public interface IUserRepository
{
    ValueTask<User?> GetByIdAsync(Guid userId);

    ValueTask<User> UpdateAsync(User user, bool saveChangesAsync = true, CancellationToken cancellationToken = default);
}