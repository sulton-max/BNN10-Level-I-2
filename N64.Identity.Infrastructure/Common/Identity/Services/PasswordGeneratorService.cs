namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class PasswordGeneratorService
{
    private static Random random = new Random();
    private const string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";

    public string GeneratePassword(int length)
    {
        return new string(Enumerable.Repeat(Chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public bool ValidatePassword(string password)
    {
        // Password should be at least 8 characters long
        if (password.Length < 8)
            return false;

        // Password should contain at least one uppercase letter
        if (!password.Any(char.IsUpper))
            return false;

        // Password should contain at least one lowercase letter
        if (!password.Any(char.IsLower))
            return false;

        // Password should contain at least one digit
        if (!password.Any(char.IsDigit))
            return false;

        // Password should contain at least one special character
        if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            return false;

        return true;
    }
}