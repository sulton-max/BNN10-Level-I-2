using System.Text.Json;
using FileStorage.ConsoleExample.Models;

namespace FileStorage.ConsoleExample;

public static class DrivesExample
{
    public static void Execute()
    {
        var drives = DriveInfo.GetDrives().ToList();

        // drive format
        // NTFS
        // FAT32
        // drive.DriveFormat

        // drive type
        // Fixed
        // Network
        // drive.DriveType
        drives
            .Select(drive => new DriveDetails
            {
                Name = drive.Name,
                Format = drive.DriveFormat,
                Type = drive.DriveType.ToString(),
                VolumeLabel = drive.VolumeLabel,
                TotalSize = drive.TotalSize,
                AvailableFreeSpace = drive.AvailableFreeSpace,
                TotalFreeSpace = drive.TotalFreeSpace
            })
            .ToList()
            .ForEach(drive => Console.WriteLine(JsonSerializer.Serialize(drive)));
    }
}