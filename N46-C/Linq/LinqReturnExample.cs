using System.Collections;
using System.Linq.Expressions;
using N46_C.Delegate;

namespace N46_C.Linq;

public static class LinqReturnExample
{
    public static IQueryable<User> Get(Expression<Func<User, bool>> expression)
    {
        var users = new List<User>();
        users.Add(new User
        {
            Age = 22
        });
        users.Add(new User
        {
            Age = 13
        });

        var query = users.Where(expression.Compile());
        return query.AsQueryable();
    }

    public static IQueryable<User> GetUsersWithAge(int age)
    {
        // returning query
        var users = new List<User>();
        var emailAddress = new List<string>();

        var service = new EmailSender();

        // var validEmailAddress = emailAddress.Where(address => service.ValidateEmail(address, address => string.IsNullOrWhiteSpace()))
        //
        // emailAddress.Select(address =>
        // {
        //
        // })
        //
        // users.Select(user =>
        // {
        //
        // })

        var query = users.Where(user => user.Age == age);

        return query.AsQueryable();
    }

    public static IList<User> GetUsers(int pageSize, int pageToken)
    {
        var users = GetUsersWithAge(10).Skip(pageSize * pageToken).Take(pageSize).ToList();
        return users;
    }
}

public class User
{
    public string FirstName { get; set; }
    public int Age { get; set; }
}