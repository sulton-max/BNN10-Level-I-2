namespace FileStorage.ConsoleExample.Models;

public class DriveDetails
{
    public string Name { get; set; } = string.Empty;

    public string Format { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string VolumeLabel { get; set; } = string.Empty;

    public long TotalSize { get; set; }

    public long AvailableFreeSpace { get; set; }

    public long TotalFreeSpace { get; set; }
}