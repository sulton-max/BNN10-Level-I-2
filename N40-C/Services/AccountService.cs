using N40_C.Models;

namespace N40_C.Services;

public class AccountService
{
    private readonly EmailSenderService _emailSenderService;
    private List<User> _users = new();
    private List<Email> _emails = new();

    public AccountService(EmailSenderService emailSenderService)
    {
        _emailSenderService = emailSenderService;
    }

    public void RegisterAsync(string emailAddress, string password)
    {
        // if (string.IsNullOrWhiteSpace(emailAddress))
        //     throw new ArgumentNullException(nameof(emailAddress));
        //
        // if (string.IsNullOrWhiteSpace(password))
        //     throw new ArgumentNullException(nameof(password));
        //
        // var foundUser = _users.First(user => user.EmailAddress == emailAddress);
        // if (foundUser != null)
        //     throw new InvalidOperationException($"Email address already exists - {emailAddress}");

        _emailSenderService.SendEmailAsync("", "", "");
    }

    // public ValueTask DoSomething(Guid userId)
    // {
    //     // if(userId == default)
    //
    //     // if(userId == default)
    //
    //     // var foundUser =
    //
    //     // userId == default || uuid.Parse() > DateTime.Now
    //
    // }
}