using System.Linq.Expressions;
using Events.Example.Api.DataAccess;
using Events.Example.Api.Models.Entities;

namespace Events.Example.Api.Services;

public class UserService
{
    private readonly AppFileContext _dataContext;

    public UserService(AppFileContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
    {
        return _dataContext.Users.Where(predicate.Compile()).AsQueryable();
    }
}