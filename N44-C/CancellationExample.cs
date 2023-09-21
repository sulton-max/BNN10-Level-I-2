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
        await DownloadAsync(cts.Token);
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
                return;

            Console.WriteLine("Creating a file ...");
            await Task.Delay(100, cancellationToken);
        }
    }
}