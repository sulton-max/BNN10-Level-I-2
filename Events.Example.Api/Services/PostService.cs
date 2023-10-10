using System.Linq.Expressions;
using Events.Example.Api.DataAccess;
using Events.Example.Api.Events;
using Events.Example.Api.Models.Entities;

namespace Events.Example.Api.Services;

public class PostService
{
    private readonly AppFileContext _dataContext;
    private readonly PostsEventStore _postsEventStore;

    public PostService(AppFileContext dataContext, PostsEventStore postsEventStore)
    {
        _dataContext = dataContext;
        _postsEventStore = postsEventStore;
    }

    public async ValueTask<BlogPost> Create(BlogPost post)
    {
        await _dataContext.Posts.AddAsync(post);
        await _dataContext.SaveChangesAsync();
        await _postsEventStore.CreatePostAddedEventAsync(post);

        return post;
    }
}