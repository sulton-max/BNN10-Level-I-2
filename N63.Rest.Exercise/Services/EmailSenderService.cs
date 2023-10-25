namespace N63.Rest.Exercise.Services;

public class EmailSenderService
{
    public ValueTask<bool> SendAsync(string emailAddress, string body, string message) => new(false);
}