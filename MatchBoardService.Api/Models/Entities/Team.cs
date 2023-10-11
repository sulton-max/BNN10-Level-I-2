namespace MatchBoardService.Api.Models.Entities;

public class Team : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string EstablishedDate { get; set; } = string.Empty;
}