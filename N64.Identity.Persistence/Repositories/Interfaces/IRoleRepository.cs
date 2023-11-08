using System.Linq.Expressions;
using N64.Identity.Domain.Entities;

namespace N64.Identity.Persistence.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> Get(Expression<Func<Role, bool>> predicate);
}