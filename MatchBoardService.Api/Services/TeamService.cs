using MatchBoardService.Api.Models.Entities;

namespace MatchBoardService.Api.Services;

public class TeamService : IEntityService
{
    public List<Team> Teams { get; init; }

    public TeamService()
    {
        Teams = new List<Team>()
        {
            new Team
            {
                Id = Guid.Parse("432085e5-3ba1-4cc7-9f4d-c42a09d54d43"),
                Name = "Real Madrid",
                EstablishedDate = "1902"
            },
            new Team
            {
                Id = Guid.Parse("0ef8a6fb-a969-4789-9f01-6376f376b8a9"),
                Name = "Barcelona",
                EstablishedDate = "1899"
            },
            new Team
            {
                Id = Guid.Parse("18289d53-d9ec-4e07-a7ad-dbe77fc82c67"),
                Name = "Pakhtakor",
                EstablishedDate = "1956"
            },
            new Team
            {
                Id = Guid.Parse("e4a1afd5-1d24-40b5-a50c-d77e7d70ce37"),
                Name = "Navbahor",
                EstablishedDate = "1962"
            }
        };
    }
}