using Events.Example;
using Microsoft.Extensions.DependencyInjection;

var builder = new ServiceCollection();

builder.AddSingleton<PostService>().AddSingleton<DiscoveryService>().AddSingleton<PostsEventStore>();

var services = builder.BuildServiceProvider();

var postService = services.GetService<PostService>() ?? throw new InvalidOperationException();
var disoveryService = services.GetRequiredService<DiscoveryService>();

var post = new Post
{
    Id = Guid.NewGuid(),
    Topic = "Cloud Computing"
};

var createdPost = await postService.Create(post);
Console.WriteLine(createdPost.Topic);