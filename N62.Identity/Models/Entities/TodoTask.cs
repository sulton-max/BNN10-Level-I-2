namespace N62.Identity.Models.Entities;

public class TodoTask
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid UserId { get; set; }
}