namespace N61.Models.CustomExceptions;

public class EntityConflictException : Exception
{
    public EntityConflictException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}