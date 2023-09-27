using N46_C;
using N46_C.Delegate;

// var users = LinqReturnExample.Get(user => user.Age > 21).ToList();
// users.ForEach(Console.WriteLine);

// Delegate
var emailSender = new EmailSender();
var validator = new Validator();
var postService = new PostService();

// // instance method
// emailSender.SendEmail("23423", validator.Validate);
//
// // static method
// emailSender.SendEmail("23423", Validator.ValidateEmail);
// emailSender.SendEmail("sdf", string.IsNullOrWhiteSpace);

// anonymous method with one line
postService.Create("", content => Validator.GetComplexWordCount(content) > 0);

// anonymous method with multiple lines
// postService.Create("", content =>
// {
//     var result = Validator. && Validator.GetComplexWordCount(content) > 0;
// });

Func<string, ValueTask> notifyUser = Notifier.SendEmail;

notifyUser += Notifier.SendSms;

notifyUser("John");

namespace N46_C
{
    // foreach (var notifier in notifyUser.GetInvocationList())
//     notifier.DynamicInvoke("John");

    public static class Notifier
    {
        public static ValueTask SendEmail(string user)
        {
            Console.WriteLine("Sending email to {0}", user);
            return new ValueTask();
        }

        public static ValueTask SendSms(string user)
        {
            Console.WriteLine("Sending sms to {0}", user);
            return new ValueTask();
        }
    }



// delegate

// multicast delegate

// Func<T> - delegate TResult Method(TParamA paramA, TParamB, paramB)
// Action<T> - delegate void Method(TParamA paramA, TParamB, paramB)
// Predicate<T> - delegate bool Method(TParamA paramA)

    public delegate bool ValidateContentDelegate(string content, bool result);

    public class PostService
    {
        public bool Create(string content, Predicate<string> validateMethod)
        {
            if (!validateMethod(content))
                throw new InvalidOperationException();

            return true;
        }
    }


    public class Validator
    {
        // Method
        public bool Validate(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    
        public static bool ValidateEmail(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static int GetComplexWordCount(string content)
        {
            return 10;
        }
    }
}