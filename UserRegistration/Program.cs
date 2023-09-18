using UserRegistration.Services;

var employeeService = new EmployeeService();
var accountService = new AccountService(employeeService);

var tasks = new List<Task>()
{
    new(() => accountService.RegisterAsync("john.doe@gmail.com").AsTask()),
    new(() => accountService.RegisterAsync("john.doe@gmail.com").AsTask()),
    new(() => accountService.RegisterAsync("john.doe@gmail.com").AsTask())
};

Parallel.ForEach(tasks, task => task.Start());
await Task.WhenAll(tasks);

employeeService.Employees.ForEach(employee => Console.WriteLine(employee.EmailAddress));