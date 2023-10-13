using DependencyInjection.Request.Api.Models;
using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileEntry;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;

namespace DependencyInjection.Request.Api.DataAccess;

public class AppFileContext : FileContext
{
    public IFileSet<InternalDocument, Guid> Documents => Set<InternalDocument, Guid>(nameof(Documents));

    public AppFileContext(IFileContextOptions<AppFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
    }

    public ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSet in fileSets)
        foreach (var entry in fileSet.GetEntries())
        {
            if (entry is not IFileEntityEntry<IFileSetEntity<Guid>> entityEntry) continue;

            if (entityEntry.State == FileEntityState.Added)
                entityEntry.Entity.Id = Guid.NewGuid();
        }

        return new ValueTask(Task.CompletedTask);
    }
}