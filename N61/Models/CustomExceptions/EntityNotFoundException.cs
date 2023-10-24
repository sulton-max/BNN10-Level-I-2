namespace N61.Models.CustomExceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(Guid id, Type type, Exception? innerException = null)
        : base($"Entity of type {type.Name} with id {id} was not found.", innerException)
    {
    }
}