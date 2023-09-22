namespace N44_C;

public static class DeadLockExample
{
    private static readonly object _lockA = new();
    private static readonly object _lockB = new();

    private static readonly User _user = new User
    {
        FirstName = "John"
    };

    public static async ValueTask ExecuteAsync()
    {
        // unnecessary
        // invalid
        // better avoided

        var tasks = new List<Task>();
        tasks.Add(Task.Run(() =>
        {
            lock (_lockA)
            {
                Console.WriteLine("Thread A acquired lock A");
                Thread.Sleep(10_000);

                lock (_lockB)
                {
                    _user.FirstName = "Jane";
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

public class User
{
    public string FirstName { get; set; }
}