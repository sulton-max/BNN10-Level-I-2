namespace N57_Writer;

public static class FileExample
{
    public static async ValueTask Execute()
    {
        var appId = Guid.NewGuid();
        var mutex = new Mutex(false, "N57-Writer");
        var random = new Random();

        var fileAbsolutePath = "D:\\notes.txt";
        await using var fileStream = File.Open(fileAbsolutePath, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
        await using var streamWriter = new StreamWriter(fileStream);
        streamWriter.AutoFlush = true;

        while (fileStream.CanWrite)
        {
            await Task.Run( () =>
            {
                mutex.WaitOne();

                Thread.Sleep(random.Next(1000, 2000));

                streamWriter.WriteLine($"Application {appId} wrote - Hello streams");

                mutex.ReleaseMutex();
            });
        }
    }
}