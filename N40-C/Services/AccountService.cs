using N40_C.Models;

namespace N40_C.Services;

public class AccountService
{
    private List<User> _users = new();
    private List<Email> _emails = new();

    public ValueTask RegisterAsync(string emailAddress, string password)
    {
        if(string.IsNullOrWhiteSpace(emailAddress))
            throw new 
    }
}