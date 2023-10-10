using Events.Example.Api.Models.Entities;

namespace Events.Example.Api.Events;

public class PostsEventStore
{
    public event Func<BlogPost, ValueTask>? OnPostCreated;

    public async ValueTask CreatePostAddedEventAsync(BlogPost post)
    {
        if (OnPostCreated != null)
            await OnPostCreated(post);
    }
}