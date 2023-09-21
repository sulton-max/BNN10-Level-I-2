namespace N43_C;

public static class ContinuationExample
{
    public static void Execute()
    {
        DownloadAsync()
            .ContinueWith(downloadResult => InstallAsync(downloadResult.Result));
    }

    public static Task<string> DownloadAsync()
    {
        return Task.Run(async () =>
        {
            var appName = "Uzum Market";
            var process = 0;
            Console.WriteLine($"\nDownloading {appName}");
            Console.WriteLine($"Executing in thread {Thread.CurrentThread.ManagedThreadId}");
            while (process < 100)
            {
                Console.WriteLine($"Loading, process - {process}%");
                process += 20;
                await Task.Delay(1000);
            }

            return appName;
        });
    }

    public static Task<string> InstallAsync(string appName)
    {
        return Task.Run(async () =>
        {
            var process = 0;
            Console.WriteLine($"Installing {appName}");
            Console.WriteLine($"Executing in thread {Thread.CurrentThread.ManagedThreadId}");
            while (process < 100)
            {
                Console.WriteLine($"\nInstalling, process - {process}%");
                process += 20;
                await Task.Delay(1000);
            }

            return appName;
        });
    }
}