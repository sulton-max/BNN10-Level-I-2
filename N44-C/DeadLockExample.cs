namespace N44_C;

public static class DeadLockExample
{
    private static readonly object _lockA = new();
    private static readonly object _lockB = new();

    public static async ValueTask ExecuteAsync()
    {
        var tasks = new List<Task>();
        tasks.Add(Task.Run(() =>
        {
            lock (_lockA)
            {
                Console.WriteLine("Thread A acquired lock A");

                Thread.Sleep(1000);
                lock (_lockB)
                {
                    Console.WriteLine("Thread A acquired lock B");
                }
            }
        }));

        tasks.Add(Task.Run(() =>
        {
            lock (_lockB)
            {
                Console.WriteLine("Thread B acquired lock B");

                Thread.Sleep(1000);
                lock (_lockA)
                {
                    Console.WriteLine("Thread B acquired lock A");
                }
            }
        }));

        await Task.WhenAll(tasks);
    }
}