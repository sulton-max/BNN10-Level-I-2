namespace MatchBoardService.Api.Models.Entities;

public class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public List<Guid> LikedTeams { get; set; } = new();
}