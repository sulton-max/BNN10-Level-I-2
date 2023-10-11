namespace MatchBoardService.Api.Models.Entities;

public class TeamMatch : IEntity
{
    public Guid Id { get; set; }

    public Guid TeamA { get; set; }

    public Guid TeamB { get; set; }

    public string Location { get; set; } = string.Empty;

    public int TeamAGoals { get; set; }

    public int TeamBGoals { get; set; }

    public DateTimeOffset MatchTime { get; set; }
}