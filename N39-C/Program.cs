// Data - ma'lumot

// Fake Data - real ma'lumotga o'xshash soxta ma'lumotlar

// Seed Data - dastur ishini boshlaganida fake data yoki real data qo'shish jarayoni
// Seed Data - environmentga qarab qaysi data qo'shilishini belgilaydi

// Shallow Copy - ma'lumotlarni nusxalash referencelarni hisobga olmasdan
// Deep Copy - ma'lumotlarni nusxalash referencelarni hisobga olgan holda

// Tynamix.ObjectFiller - fake data

#region Deep Clone

// using Force.DeepCloner;
// using Tynamix.ObjectFiller;
//
// var random = new Random();
// var filler = new Filler<User>();
// filler.Setup().OnProperty(property => property.Age).Use(random.Next(15, 70));
//
// var user = filler.Create();
//
// Console.WriteLine("user - " + user.Orders[0].ProductName);
//
// var clone = user.DeepClone();
// clone.Orders[0].ProductName = "Table";
// Console.WriteLine("user - " + clone.Orders[0].ProductName);
// Console.WriteLine("user - " + user.Orders[0].ProductName);

// Deep Cloner - Deep Copy

#endregion

#region Pattern matching

// Type pattern
using System.Linq.Expressions;
using N39_C;

object value = new User()
{
    FirstName = "John",
    LastName = "Wick"
};

if (value is User)
{
    var user = value as User;
    Console.WriteLine(user.FirstName);
}

// Declaration type pattern
object valueB = "Hello, World!";
if (valueB is string greeting)
{
    Console.WriteLine(greeting);
}

// Constant pattern
object valueC = 100;
if (valueC is 100)
{
    Console.WriteLine("valueC is 100");
}

var langLevel = LanguageLevel.Advanced;

// relational pattern
var resultA = langLevel switch
{
    >= LanguageLevel.Intermediate => "your level is good",
    _ => "you need to learn more"
};

// const pattern - comparing discrete values
var resultB = langLevel switch
{
    LanguageLevel.Beginner => "your score is below 60",
    LanguageLevel.Intermediate => "your score is below 80",
    LanguageLevel.Advanced => "your score is below 100",
};

var users = new List<User>()
{
    new User
    {
        FirstName = "Jonibek",
        Age = 14
    },
    new User
    {
        FirstName = "Jonibek",
        Age = 24
    },
};

// Property pattern
var exactJonibek = users.FirstOrDefault(user => user is { FirstName: "Jonibek", Age: 14});
// Console.WriteLine(exactJonibek.Age);

// Discard pattern
var result = (FirstName: "John", LastName: "Doe", Age: 20);
var (_, LastName, _ ) = result;

// Console.WriteLine(LastName);

#endregion

#region



// declaraation type pattern

try
{
    var rentalService = new RentalService();
    rentalService.RentCar(default);
}
catch (ArgumentOutOfRangeException ex) when (ex is { ParamName: "carId", Message: "Car id cannot be empty (Parameter 'carId')" })
{
    Console.WriteLine("Either frontend or backed validation not working");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}


#endregion
