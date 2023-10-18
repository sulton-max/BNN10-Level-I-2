namespace FileExplorer.Api.Models;

public interface IStorageEntry
{
    string Path { get; set; }

    StorageItemType ItemType { get; set; }
}