namespace N62.Identity.Models.Entities;

public class User
{
    public Guid Id { get; set; }

    public string EmailAddress { get; set; } = string.Empty;
    public object Password { get; set; }
}