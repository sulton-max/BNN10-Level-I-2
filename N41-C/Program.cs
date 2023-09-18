// using N41_C.Exceptions;
// using N41_C.Services;

// try
// {
//     var service = new RecommendationService();
//     service.GetRecommendations();
// }
// catch(ExceptionBase exception)
// {
//     Console.WriteLine(exception.Message);
//     Console.WriteLine(exception.Severity);
// }

//
// using N41_C.Services;
//
// for (var index = 0; index < 100; index++)
// {
//     var paymentService = new PaymentService();
//     var tasks = new List<Task>()
//     {
//         new(() => paymentService.Withdraw(600).AsTask().Wait()),
//         new(() => paymentService.Withdraw(600).AsTask().Wait())
//     };
//
//     Parallel.ForEach(tasks, task => task.Start());
// }

var path = @"D:\interview.txt";