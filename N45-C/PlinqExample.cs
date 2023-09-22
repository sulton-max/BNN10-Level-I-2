using Bogus;
using N45_C.LinqSyntaxExample;

namespace N45_C;

public static class PlinqExample
{
    public static async Task Execute()
    {
        var tags = new List<string>
        {
            "it",
            "programming",
            "devops",
            "qa",
            "media",
            "gm"
        };

        var blogPostFaker = new Faker<BlogPost>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.Title, source => source.Lorem.Text())
            .RuleFor(keySelector => keySelector.Context, source => source.Lorem.Text())
            .RuleFor(keySelector => keySelector.Tag, source => source.PickRandom(tags));

        var posts = blogPostFaker.Generate(10);

        // subscription - 4 core, 8 Gb
        // pay-as-you go - 2 core, 4 GB, 16 core, 32 GB

        var postProcessingQueryA = posts
            .Select(post =>
            {
                return Task.Run(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Finished processing the post");
                    return post;
                });
            })
            .ToList();

        var postProcessingQueryB = posts
            .AsParallel()
            .Select(post =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Finished processing the post");

                return post;
            });
            // .ToList();

        Console.WriteLine("doing something");
        await Task.WhenAll(postProcessingQueryA);

        Console.WriteLine("Tugadi...");

        //
        // foreach(var post in postProcessingQueryB)
        //     Console.WriteLine(post.Title);
    }
}