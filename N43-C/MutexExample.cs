namespace N43_C;

public static class MutexExample
{
    public static Task ExecuteAsync()
    {
        var filePath = @"D:\interview.txt";
        var mutex = new Mutex(false, "OpenFileMutex");

        return Task.Run(() =>
        {
            mutex.WaitOne();
            var guid = Guid.NewGuid();
            var fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite);
            Console.WriteLine($"App {guid} opened the file");

            Thread.Sleep(10_000);

            fileStream.Close();
            Console.WriteLine($"App {guid} closed the file");
            mutex.ReleaseMutex();
        });
    }
}