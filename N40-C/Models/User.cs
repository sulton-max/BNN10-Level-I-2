namespace N40_C.Models;

public class User
{
    public string EmailAddress { get; set; }
    public string Password { get; set; }

    public User(string emailAddress, string password)
    {
        EmailAddress = emailAddress;
        Password = password;
    }
}