using System.Linq.Expressions;
using N67.Application.Common.Identity.Services;
using N67.Domain.Entities;
using N67.Persistence.DataContexts;

namespace N67.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _appDbContext;

    public UserService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null) =>
        predicate != null ? _appDbContext.Users.Where(predicate) : _appDbContext.Users;

    public ValueTask<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return _appDbContext.Users.FindAsync(userId);
    }

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _appDbContext.Users.AddAsync(user, cancellationToken);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        _appDbContext.Users.Update(user);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        _appDbContext.Users.Remove(user);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask<User> DeleteByIdAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = _appDbContext.Users.Find(userId);

        if (foundUser is null)
            throw new InvalidOperationException($"User with id {userId} not found.");

        _appDbContext.Users.Remove(foundUser);

        if (saveChanges)
            await _appDbContext.SaveChangesAsync(cancellationToken);

        return foundUser;
    }
}