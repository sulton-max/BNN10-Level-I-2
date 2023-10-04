using Di.Api.Models.Entities;
using FileBaseContext.Abstractions.Models.FileSet;

namespace Di.Api.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    ValueTask SaveChangesAsync();
}