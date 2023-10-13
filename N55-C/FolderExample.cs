namespace N55_C;

public static class FolderExample
{
    public static void Execute()
    {
        var appFolder = Directory.GetCurrentDirectory();

        var folderName = "Resumes";
        var folderAbsolutePath = Path.Combine("D:\\Temp\\Data", folderName);

        // Create
        Directory.CreateDirectory(folderName);
        Directory.CreateDirectory(folderAbsolutePath);

        // Enumerate

        // Entry - abstract, directory yoki file
        // Directory - papka, folder, fayllarni guruhlab turadigan narsa
        // File - binary yoki text formatdagi ma'lumotlar

        var entries = Directory.EnumerateFileSystemEntries(appFolder);
        var folder = Directory.GetDirectories(appFolder);
        var files = Directory.GetFiles(appFolder, "*.exe");

        // Delete - empty bo'lmasa exception bo'ladi qachonki recursive true berilmasa

        // Directory.Delete(
        //     "D:\\Projects\\Repositories\\Training\\Groups\\Bootcamp N10\\Classes\\BNN10-Level-I-2\\N55-C\\bin\\Debug\\net7.0\\Data\\DataStorage",
        //     true);

        // Move
        // Directory.Move(@"D:\Temp\Data", Path.Combine(appFolder, "Data"));

        // Parent
        Console.WriteLine(Directory.GetParent(appFolder));

        // Drive
        var drives = Directory.GetLogicalDrives();
    }
}