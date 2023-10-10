namespace Events.Example;

public class PostService
{
    private readonly PostsEventStore _eventStore;

    public PostService(PostsEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async ValueTask<Post> Create(Post post)
    {
        // post ni bazaga yozish

        await _eventStore.CreatePostAddedEventAsync(post);

        return post;
    }
}