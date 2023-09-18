namespace N41_C.Services;

public class PaymentService
{
    private int _balance = 1000;
    private readonly object _lock = new();

    public async ValueTask Withdraw(int amount)
    {
        await Task.Delay(1000);

        // race condition - threadlar poyga holatida bitta threadga murojaat qilishi
        var canWithdraw = false;
        lock (_lock)
        {
            canWithdraw = _balance > amount;
            if (!canWithdraw)
                return;

            Task.Delay(1000).Wait();
            _balance -= amount;
        }

        if (_balance < 0 && canWithdraw)
            Console.WriteLine($"Wow! You are in debt! Thread id - {Thread.CurrentThread.ManagedThreadId}");

        Console.WriteLine("Subscription uchun rahmat");

        Console.WriteLine("To'lovingiz qabul qilindi");
    }
}