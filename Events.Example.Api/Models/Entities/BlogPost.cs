namespace Events.Example.Api.Models.Entities;

public class BlogPost : IEntity
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public List<string> Topic { get; set; } = new();

    public Guid AuthorId { get; set; }
}