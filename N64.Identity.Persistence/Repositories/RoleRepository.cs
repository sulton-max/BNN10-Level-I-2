using System.Linq.Expressions;
using N64.Identity.Domain.Entities;
using N64.Identity.Persistence.DataContexts;
using N64.Identity.Persistence.Repositories.Interfaces;

namespace N64.Identity.Persistence.Repositories;

public class RoleRepository: EntityRepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(IdentityDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Role> Get(Expression<Func<Role, bool>> predicate)
    {
        return base.Get(predicate);
    }
}