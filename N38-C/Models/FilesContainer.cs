using System.Collections;

namespace N38_C.Models;

public class FilesContainer : IEnumerable<FileInfo>
{
    private readonly List<FileInfo> _filesPaths;

    public FilesContainer(string directoryPath)
    {
        var directory = new DirectoryInfo(directoryPath);
        _filesPaths = directory.GetFiles("*.cs", SearchOption.AllDirectories).ToList();
    }

    public IEnumerator<FileInfo> GetEnumerator()
    {
        return _filesPaths.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public FileInfo this[int index] => _filesPaths[index];

    public FileInfo this[string keyword] => _filesPaths.First(x => x.Name.Contains(keyword));
}