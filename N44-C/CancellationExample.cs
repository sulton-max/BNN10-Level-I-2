namespace N44_C;

public static class CancellationExample
{
    public static async ValueTask Execute()
    {
        // Concurrency - async programming, multhi threading

        // Cancellation - uzoq vaqt oladigan tasklarni cancel qilish uchun
        // CancellationTokenSource - cancel qilish uchun manba - bu asosiy boshqaruvchi threadda yaratiladi
        // CancellationToken - cancel qilinganini bildiruvchi obyekt/flag - bu threadlarga beriladi

        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

        try
        {
            await DownloadAsync(cts.Token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static async ValueTask DownloadAsync(CancellationToken cancellationToken)
    {
        // if (cancellationToken.IsCancellationRequested)
        //     return
        //
        // cancellationToken.ThrowIfCancellationRequested();

        for (var index = 0; index < 100; index++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Download canceled");
                return;
            }

            Console.WriteLine("Downloading a file ...");

            await Task.Delay(100, cancellationToken); // cancel qilish so'ralgan bo'lsa - exception qaytaradi
        }
    }
}