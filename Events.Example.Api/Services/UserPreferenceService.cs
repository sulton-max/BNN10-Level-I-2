using System.Linq.Expressions;
using Events.Example.Api.DataAccess;
using Events.Example.Api.Models.Entities;

namespace Events.Example.Api.Services;

public class UserPreferenceService
{
    private readonly AppFileContext _dataContext;

    public UserPreferenceService(AppFileContext dataContext)
    {
        _dataContext = dataContext;
    }

    public IQueryable<UserPreference> Get(Expression<Func<UserPreference, bool>> predicate)
    {
        return _dataContext.UserPreferences.Where(predicate.Compile()).AsQueryable();
    }
}