using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.Api.Models;

public class StorageDirectory : IStorageEntry
{

    public StorageDirectory()
    {
        if (Directory.Exists(""))
            throw new UserFileUpdateException();

    }
    public string Name { get; set; } = string.Empty;

    public string Path { get; set; } = string.Empty;

    public long ItemsCount { get; set; }

    public StorageItemType ItemType { get; set; } = StorageItemType.Directory;
}