using Example.Backend.Domain.Entities;

namespace Example.Backend.Application.Accounts.Models;

public class UserDto
{
    public string FirstName { get; set; }

    public static explicit operator UserDto(User user)
    {
        return new UserDto();
    }

    public static explicit operator User(UserDto user)
    {
        return new User();
    }
}