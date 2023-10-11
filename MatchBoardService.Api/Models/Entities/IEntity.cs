using FileBaseContext.Abstractions.Models.Entity;

namespace MatchBoardService.Api.Models.Entities;

public interface IEntity : IFileSetEntity<Guid>
{
}