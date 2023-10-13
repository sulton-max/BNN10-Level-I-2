using FileBaseContext.Abstractions.Models.Entity;

namespace DependencyInjection.Request.Api.Models;

public class InternalDocument : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
}