namespace N67.Domain.Entities;

public class Role
{
    public Guid UserId { get; set; }

    public string Name { get; set; } = default!;
}