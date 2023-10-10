namespace Events.Example;

public class PostsEventStore
{
    public event Func<Post, ValueTask>? OnPostCreated;

    public async ValueTask CreatePostAddedEventAsync(Post post)
    {
        if (OnPostCreated != null)
            await OnPostCreated(post);
    }
}