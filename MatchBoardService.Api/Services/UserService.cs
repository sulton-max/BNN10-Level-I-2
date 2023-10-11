using MatchBoardService.Api.Models.Entities;

namespace MatchBoardService.Api.Services;

public class UserService
{
    public List<User> Users { get; init; }

    public UserService()
    {
        Users = new List<User>
        {
            new User()
            {
                Id = Guid.Parse("140b91e0-17a6-4110-b125-a9c6891f329e"),
                UserName = "ShowSpeed",
                LikedTeams = new List<Guid>()
                {
                    Guid.Parse("e4a1afd5-1d24-40b5-a50c-d77e7d70ce37"),
                    Guid.Parse("18289d53-d9ec-4e07-a7ad-dbe77fc82c67")
                }
            },
            new User()
            {
                Id = Guid.Parse("140b91e0-17a6-4110-b125-a9c6891f329e"),
                UserName = "John",
                LikedTeams = new List<Guid>()
                {
                    Guid.Parse("432085e5-3ba1-4cc7-9f4d-c42a09d54d43"),
                    Guid.Parse("18289d53-d9ec-4e07-a7ad-dbe77fc82c67")
                }
            },
            new User()
            {
                Id = Guid.Parse("140b91e0-17a6-4110-b125-a9c6891f329e"),
                UserName = "Jane",
                LikedTeams = new List<Guid>()
                {
                    Guid.Parse("432085e5-3ba1-4cc7-9f4d-c42a09d54d43"),
                    Guid.Parse("0ef8a6fb-a969-4789-9f01-6376f376b8a9")
                }
            }
        };
    }
}