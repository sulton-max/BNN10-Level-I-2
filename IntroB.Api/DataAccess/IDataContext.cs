using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileSet;
using IntroB.Api.Models;

namespace IntroB.Api.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    ValueTask SaveChangesAsync();
}