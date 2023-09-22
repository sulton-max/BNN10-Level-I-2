using System.Text.Json;
using Bogus;

namespace N45_C.LinqSyntaxExample;

// BlogMaanger - blog topiklaridan foydalanuvchilarga eng ko'p yoqadiganlarini topib beruvchi dastur tuzing
//
// eslatma : linqdan foydalanish mumkinmas
//
//     - BlogPost nomli tip yarating
//     - BlogPost tipida unda quyidagi fieldlar bo'lsin
//     - Id
//     - Title
//     - Content
//     - Tag ( mavzular, vergul bilan ajratilgan - "csharp, js, ai" )
//     - Likes - like lar soni
//     - Dislikes - dislike lar soni
//
//     - BlogManager nomli tip yarating unda Analyze methodi bo'lsin
//     - Analyze methodi
//     - List<BlogPost> kolleksiya tipidagi parameteri bo'lib bloglarni analiz qilishi kerak
//     - blog topiklaridan nechta takrorlanmas ( unique, distinct ) topic borligini toping
//     - topiklarni va ularga mos contentlarni key-value qilib saqlang, bunda contentlar List tipida bo'lsin
//     - har bitta topic bo'yicha postlarni yoqish darajasini hisoblang ( likes - dislikes )
//     - topiklarni yoqqanlik bo'yicha saralab, o'rtacha tekst uzunligi qancha bo'lganligini hisoblang
//     - ekraga topiklarni yoqqanlik bo'yicha saralab, va shu topik bo'yicha o'rtacha kontent uzunligini chiqaring

public static class LinqSyntaxExample
{
    public static void Execute()
    {
        var random = new Random(1);
        Randomizer.Seed = random;

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

        var blogPosts = blogPostFaker.Generate(100);
        var blogPostStack = new Stack<BlogPost>(blogPosts);

        // var index = 0;
        var blogPostFeedbackFaker = new Faker<BlogFeedback>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            // .RuleFor(keySelector => keySelector.BlogId, source => source.Lorem.Text())
            // .RuleFor(keySelector => keySelector.BlogId, () => blogPosts.Skip(index++).First().Id)
            .RuleFor(keySelector => keySelector.BlogId, () => blogPostStack.Pop().Id)
            .RuleFor(keySelector => keySelector.Likes, () => random.Next(0, 5_000))
            .RuleFor(keySelector => keySelector.Dislikes, () => random.Next(0, 5_000));

        var blogCommentsFaker = new Faker<BlogComment>()
            .RuleFor(keySelector => keySelector.Id, Guid.NewGuid)
            .RuleFor(keySelector => keySelector.BlogId, source => source.PickRandom(blogPosts).Id)
            .RuleFor(keySelector => keySelector.Comment, source => source.Lorem.Text());

        var blogPostFeedbacks = blogPostFeedbackFaker.Generate(100);
        var blogComments = blogCommentsFaker.Generate(10_000);

        // query syntax 1

        // like - 3
        // dislike - 1

        // Method Syntax
        // var blogFeedbacks = blogPosts
        //     .Join(blogPostFeedbacks,
        //         post => post.Id,
        //         feedback => feedback.BlogId,
        //         (post, feedback) => new
        //         {
        //             Post = post,
        //             Score = feedback.Likes * 3 - feedback.Dislikes
        //         })
        //     .OrderByDescending(postScore => postScore.Score);

        // TODO : fix group by
        // Query syntax
        var blogFeedbacks = from post in blogPosts
            join postFeedback in blogPostFeedbacks on post.Id equals postFeedback.BlogId
            join postComment in blogComments on post.Id equals postComment.BlogId
            let score = postFeedback.Likes * 3 - postFeedback.Dislikes
            orderby score descending
            // group post by post.Id into posts
            select new
            {
                Post = post,
                Score = score,
                Feedback = postFeedback,
                Comment = postComment
            };

        var result = from post in blogFeedbacks group post by post.Post;

        File.WriteAllText("D:\\Projects\\Repositories\\Training\\Groups\\Bootcamp N10\\Classes\\BNN10-Level-I-2\\N45-C\\data.json",
            JsonSerializer.Serialize(result));
    }
}

public class BlogPost
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Context { get; set; }
    public string Tag { get; set; }
}

public class BlogFeedback
{
    public Guid Id { get; set; }
    public Guid BlogId { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
}

public class BlogComment
{
    public Guid Id { get; set; }
    public Guid BlogId { get; set; }
    public string Comment { get; set; }
}