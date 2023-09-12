namespace N36_C;

public record User(string Name, string Email, string Phone);

public record FilterPagination(int PageToken, int PageSize)
{
    // public FilterPagination() : this(1, 10)
    // {
    // }
}

public record UserFilterModel(string Role) : FilterPagination(0, 0);


// public record User()
// {
//     public string Name { get; init; }
//     public readonly string Email;
//     public readonly string Phone;
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