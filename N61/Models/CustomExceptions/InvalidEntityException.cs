namespace N61.Models.CustomExceptions;

public class InvalidEntityException : Exception
{
    public InvalidEntityException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}