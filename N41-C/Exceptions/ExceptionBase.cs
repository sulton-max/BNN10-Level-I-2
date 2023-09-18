namespace N41_C.Exceptions;

public enum ErrorSeverity
{
    Low,
    Medium,
    High
}

public abstract class ExceptionBase : Exception
{
    public virtual ErrorSeverity Severity { get; }

    public ExceptionBase()
    {
    }

    public ExceptionBase(string message) : base(message)
    {
    }

    public ExceptionBase(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class RecommendationServiceException : ExceptionBase
{
    public override ErrorSeverity Severity => ErrorSeverity.Low;

    public RecommendationServiceException()
    {
    }

    public RecommendationServiceException(string message) : base(message)
    {
    }

    public RecommendationServiceException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
