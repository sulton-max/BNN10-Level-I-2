using N36_C;
using N36_C.Services;

#region MyRegion

// constructor
var userA = new User("Jonibek", "john.doe@example.com", "234234324");
var userB = new User("Jonibek", "john.doe@example.com", "234234324");

// displaying
Console.WriteLine(userA);

// equality
Console.WriteLine(userA.Equals(userB));

#endregion

#region Tuple

var service = new PerformanceReportService();
var users = new List<User>
{
    new User("Jonibek", "john.doe@example.com", "234234324"),
    new User("Jonibek", "john.doe@example.com", "234234324")
};

var userFilePaths = await service.InitializeEmployeeFileDataAsync(users);
userFilePaths.ToList()
    .ForEach(result =>
    {
        Console.WriteLine(result.FilePath);
        Console.WriteLine(result.User);
    });

// tuple
var tupleA = new Tuple<Tuple<int, int>, string>(new Tuple<int, int>(10, 10), "john");
var tupleB = Tuple.Create(10, "john");

// invalid
// tupleA.Item1 = 20;

// value tuple
var valueTupleA = ValueTuple.Create(10, "john");
valueTupleA.Item1 = 10;

// syntactic sugar
var valueTupleB = (Age: 10, Name: "john");
var valueTupleC = (10, "john");
valueTupleB.Age = 20;

// deconstructing
var (age, firstName) = valueTupleB;

namespace N36_C
{
    #endregion

    public interface ICoordination
    {
        public int PointX { get; set; }
        public int PointY { get; set; }
    }

    public struct Coordination : ICoordination
    {
        public int PointX { get; set; }
        public int PointY { get; set; }
    }

// public class User
// {
//     public string Name { get; set; }
//     public string Email { get; set; }
//     public string Phone { get; set; }
//
//     public User(string name, string email, string phone)
//     {
//         Name = name;
//         Email = email;
//         Phone = phone;
//     }
//
//     public override string ToString()
//     {
//         return $"Name: {Name}, Email: {Email}, Phone: {Phone}";
//     }
//
//     public override bool Equals(object obj)
//     {
//         return obj?.GetHashCode().Equals(this.GetHashCode()) ?? false;
//     }
//
//     public override int GetHashCode()
//     {
//         return HashCode.Combine(Name, Email, Phone);
//     }
// }
}