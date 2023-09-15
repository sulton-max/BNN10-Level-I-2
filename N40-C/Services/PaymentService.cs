namespace N40_C.Services;

public class PaymentService
{
    private int _balance = 1000;
    private Guid _id = Guid.NewGuid();
    private readonly object _lock = new();
    private readonly Mutex _semaphore = new Semaphore(1, 1);

    public async ValueTask Withdraw(int amount)
    {
        var canWithdraw = _balance > amount;
        if (!canWithdraw)
            return;

        _semaphore.GetSafeWaitHandle();
        _balance -= amount;
        await Task.Delay(1000);

        if (_balance < 0 && canWithdraw)
            Console.WriteLine($"Wow! You are in debt! Thread id - {Thread.CurrentThread.ManagedThreadId}, Service id - {_id}");
    }
}