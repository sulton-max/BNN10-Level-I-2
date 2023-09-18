namespace UserRegistration.Exceptions;

public class DuplicateEntryException : Exception
{
    public DuplicateEntryException()
    {
    }

    public DuplicateEntryException(string message) : base(message)
    {
    }

    public DuplicateEntryException(string message, Exception innerException) : base(message, innerException)
    {
    }
}