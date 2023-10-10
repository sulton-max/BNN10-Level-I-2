namespace Events.Example;

public class DiscoveryService
{
    private readonly PostsEventStore _postsEventStore;

    public DiscoveryService(PostsEventStore postsEventStore)
    {
        _postsEventStore = postsEventStore;

        _postsEventStore.OnPostCreated += HandlePostCreatedEventAsync;
    }

    public ValueTask HandlePostCreatedEventAsync(Post post)
    {
        // var value = new List<UserPreferences>();
        //
        // var userPreferences = value.Where(userPreference => userPreference.Topics.Contains(post.Topic)).ToList();
        //
        // //

        Console.WriteLine($"Notifying users who likes the topic - {post}");

        return new ValueTask();
    }
}

public class UserPreferences
{
    public List<string> Topics { get; set; } = new();
}