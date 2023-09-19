using UserRegistration.Exceptions;
using UserRegistration.Models;

namespace UserRegistration.Services;

public class AccountService
{
    private readonly EmployeeService _employeeService;
    private object _lock = new();

    public AccountService(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public ValueTask RegisterAsync(string emailAddress)
    {
        lock (_lock)
        {
            var foundEmployee = _employeeService.GetByEmail(emailAddress);
            if (foundEmployee is not null)
            {
                Console.WriteLine("duplicate entry");
                return new ValueTask(Task.CompletedTask);
                // throw new DuplicateEntryException($"{nameof(Employee)} with this email address already exits.");
            }
        }

        Thread.Sleep(3000);
        var employee = new Employee
        {
            EmailAddress = emailAddress
        };
        _employeeService.Add(employee);

        return new ValueTask(Task.CompletedTask);
    }
}