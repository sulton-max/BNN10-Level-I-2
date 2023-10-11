using Events.Example.Api.Events;
using Events.Example.Api.Models.Entities;

namespace Events.Example.Api.Services;

public class DiscoveryService
{
    private readonly PostsEventStore _postsEventStore;
    private readonly UserPreferenceService _userPreferenceService;
    private readonly UserService _userService;

    public DiscoveryService(PostsEventStore postsEventStore, UserPreferenceService userPreferenceService, UserService userService)
    {
        _postsEventStore = postsEventStore;
        _userPreferenceService = userPreferenceService;
        _userService = userService;

        _postsEventStore.OnPostCreated += HandlePostCreatedEventAsync;
    }

    public ValueTask HandlePostCreatedEventAsync(BlogPost post)
    {
        var matchedUsersQuery = from preference in _userPreferenceService.Get(x => true)
            join user in _userService.Get(x => true) on preference.UserId equals user.Id
            where preference.LikedTopics.Any(topic => post.Topic.Contains(topic))
            select user;

        var matchedUsers = matchedUsersQuery.ToList();

        foreach (var user in matchedUsers)
            Console.WriteLine($"Notifying user - {user.UserName} about the post - {post.Title} with topic - {post.Topic}");

        return new ValueTask();
    }
}