namespace N42_C;

public class SemaphoreExample
{
    private static SemaphoreSlim semaphore;

    // A padding interval to make the output more orderly.
    private static int padding;

    public static void Execute()
    {
        // Semaphore - bu resursni bir nechta threadlar ishlatishiga ruxsat beriladi

        // Initial Count - boshida nechta threadga ruxsat berilganligii
        // Max Count - jarayon davomida nechta threadgacha ruxsat berilganligi

        // Release - threadni ichidagi sonsiz release qilinadi, bunda semaphore da bitta keyingi threadga ruxsat beriladi
        // Release ( count ) - bu umumiy jarayon boshlanishida nechta threadga ruxsat berilishi

        // Initial Count va tashqaridan Release qilish - initial count - concurrency, release - parallelism

        semaphore = new SemaphoreSlim(5, 10);
        Console.WriteLine("{0} tasks can enter the semaphore.", semaphore.CurrentCount);
        var tasks = new List<Task>();

        // Create and start five numbered tasks.
        for (var i = 0; i <= 4; i++)
        {
            tasks.Add(Task.Run(() =>
            {
                Console.WriteLine("Task {0} begins and waits for the semaphore.", Task.CurrentId);

                int semaphoreCount;
                semaphore.Wait();
                try
                {
                    Interlocked.Add(ref padding, 100);
                    Console.WriteLine("Task {0} enters the semaphore. time - {1}", Task.CurrentId, DateTime.Now.ToString("T"));
                    Thread.Sleep(1000 + padding);
                }
                finally
                {
                    semaphoreCount = semaphore.Release();
                }

                Console.WriteLine("Task {0} releases the semaphore; previous count: {1}.", Task.CurrentId, semaphoreCount);
                Console.WriteLine("Task {0} releases the semaphore; current count: {1}.", Task.CurrentId, semaphore.CurrentCount);
            }));
        }

        Thread.Sleep(5000);

        // Restore the semaphore count to its maximum value.
        Console.Write("Main thread calls Release(3) --> ");
        // semaphore.Release(3);
        Console.WriteLine("{0} tasks can enter the semaphore.", semaphore.CurrentCount);
        // Main thread waits for the tasks to complete.
        Task.WaitAll(tasks.ToArray());

        Console.WriteLine("Main thread exits.");
    }
}