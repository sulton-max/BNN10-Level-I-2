using FileBaseContext.Abstractions.Models.Entity;

namespace Events.Example.Api.Models.Entities;

public interface IEntity : IFileSetEntity<Guid>
{
    
}