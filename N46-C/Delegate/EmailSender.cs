namespace N46_C.Delegate;

// public interface IEmailValidator
// {
//     bool ValidateEmail(string emailAddress, Func<string, bool> validate);
//
//     bool ValidateEmail(string emailAddress, Func<string, bool> validate);
//
//     bool ValidateEmail(string emailAddress, Func<string, bool> validate);
//
//     bool ValidateEmail(string emailAddress, Func<string, bool> validate);
// }

public class EmailSender
{
    public void SendEmail(string emailAddress, ValidateEmailDelegate validateEmailDelegate)
    {
        if (!validateEmailDelegate(emailAddress))
            throw new InvalidOperationException();

        Console.WriteLine("Sending email ...");
    }
}

public delegate bool ValidateEmailDelegate(string emailAddress);