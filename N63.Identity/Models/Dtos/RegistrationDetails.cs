namespace N63.Identity.Models.Dtos;

public class RegistrationDetails
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public int Age { get; set; }

    public string EmailAddress { get; set; } = default!;

    public string Password { get; set; } = default!;
}