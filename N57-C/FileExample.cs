namespace N57_C;

public static class FileExample
{
    public static void Execute()
    {
        var fileAbsolutePath = "D:\\notes.txt";
        var fileStream = File.Open(fileAbsolutePath, FileMode.Open, FileAccess.Read, FileShare.Write);
        var streamReader = new StreamReader(fileStream);

        while (fileStream.CanRead)
        {
            var content = streamReader.ReadLine();
            if (!string.IsNullOrEmpty(content)) Console.WriteLine(content);
        }
    }
}