namespace N57_Reader;

public static class FileExample
{
    public static async ValueTask Execute()
    {
        var fileAbsolutePath = "D:\\notes.txt";
        var fileStream = File.Open(fileAbsolutePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        var streamReader = new StreamReader(fileStream);

        while (fileStream.CanRead)
        {
            var content = streamReader.ReadLine();
            if (!string.IsNullOrEmpty(content)) Console.WriteLine(content);
        }
    }
}