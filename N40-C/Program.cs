// create race condition with payment service

using N40_C.Services;

for (var index = 0; index < 1_000; index++)
{
    var paymentService = new PaymentService();
    var tasks = new List<Task>()
    {
        new(() => paymentService.Withdraw(600).AsTask().Wait()),
        new(() => paymentService.Withdraw(600).AsTask().Wait())
    };

    Parallel.ForEach(tasks, task => task.Start());
}
















