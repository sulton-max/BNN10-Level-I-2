using N40_C.Services;

// try
// {
//     var accountService = new AccountService();
//     accountService.RegisterAsync("", "");
// }
// catch (ArgumentException ex)
// {
//     Console.WriteLine(ex.Message);
// }
// catch (InvalidOperationException ex)
// {
//     Console.WriteLine(ex.Message);
// }
// catch (Exception ex)
// {
//     Console.WriteLine(ex.Message);
// }

// FormatException(); // pdf - ochilmadi
// NotSupportedException() // txt

// EntityNotFoundException - NullReferenceException
// FileNotFoundException

// ServiceFailureException -

// var maxValue = int.MaxValue;
//
// Console.WriteLine(int.MaxValue);
// Console.WriteLine(int.MinValue);
//
// checked
// {
//     maxValue++;
//     Console.WriteLine(maxValue);
//
//     unchecked
//     {
//         maxValue = int.MaxValue;
//         maxValue++;
//
//         Console.WriteLine(maxValue);
//     }
// }

// var test = new Test();
// test.DoSomething();
//
// public class Test
// {
//     public void DoSomething()
//     {
//         DoSomething();
//     }
// }

// ArgumentException: Thrown when an argument is invalid or out of range.
// ArgumentNullException: Thrown when a null argument is passed to a method that does not accept it.
// ArgumentOutOfRangeException: Thrown when an argument is outside the range of valid values.
// DivideByZeroException: Thrown when an attempt is made to divide by zero.
// FormatException: Thrown when a string cannot be parsed into the expected format.
// IndexOutOfRangeException: Thrown when an index is outside the bounds of an array or collection.
// InvalidOperationException: Thrown when an operation is invalid for the current state of an object.
// KeyNotFoundException: Thrown when a key is not found in a dictionary or collection.
// NotSupportedException: Thrown when an operation is not supported by an object or implementation.
// NullReferenceException: Thrown when a null reference is dereferenced.
// ObjectDisposedException: Thrown when an operation is performed on a disposed object.
// OutOfMemoryException: Thrown when there is not enough memory to allocate an object.
// OverflowException: Thrown when an arithmetic operation overflows.
// StackOverflowException: Thrown when the call stack overflows due to too many nested method calls.
// TimeoutException: Thrown when an operation times out.
// AggregateException: Thrown when one or more exceptions occur during the execution of a task or operation.
// FileNotFoundException: Thrown when a file is not found.
// DirectoryNotFoundException: Thrown when a directory is not found.
// IOException: Thrown when an I/O error occurs.
// UnauthorizedAccessException: Thrown when access to a resource is denied.

var emailSenderService = new EmailSenderService();
var accountService = new AccountService(emailSenderService);

try
{
    accountService.RegisterAsync("", "");
}
catch(InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}
