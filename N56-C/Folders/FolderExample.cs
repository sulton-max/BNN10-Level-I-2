namespace N56_C.Folders;

public static class FolderExample
{
    public static void Execute()
    {
        var directoryAbsolutePath = "D:\\Projects\\Repositories\\Training\\Groups\\Bootcamp N10\\Classes\\BNN10-Level-I-2\\N56-C\\bin\\Debug\\net7.0";

        // enumeration
        // var files = Directory.GetFiles("");
        // var directories = Directory.GetDirectories("");
        // var entries = Directory.GetFileSystemEntries("");
        //
        // var filesB = Directory.EnumerateFiles("");
        // var directoriesB = Directory.EnumerateDirectories("");
        // var entriesB = Directory.EnumerateFileSystemEntries("");

        var directories = Directory.GetDirectories(directoryAbsolutePath);

        Console.WriteLine("Before change");
        foreach(var directory in directories)
            Console.WriteLine(directory);

        Console.WriteLine("After change");
        foreach(var directory in directories)
            Console.WriteLine(directory);

        var directoriesB = Directory.EnumerateDirectories(directoryAbsolutePath);

        Console.WriteLine("Before change");
        foreach(var directory in directoriesB)
            Console.WriteLine(directory);

        Console.WriteLine("After change");
        foreach(var directory in directoriesB)
            Console.WriteLine(directory);
    }
}