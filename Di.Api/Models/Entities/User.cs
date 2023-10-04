using FileBaseContext.Abstractions.Models.Entity;

namespace Di.Api.Models.Entities;

public class User : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }
    public string Username { get; set; }
}