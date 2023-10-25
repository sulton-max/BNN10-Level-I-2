using System.Security.Authentication;
using Microsoft.AspNetCore.Authorization;
using N63.Identity.Models.Dtos;
using N63.Identity.Models.Entities;
using BC = BCrypt.Net.BCrypt;

namespace N63.Identity.Service;

public class AuthService
{
    private readonly TokenGeneratorService _tokenGeneratorService;

    public AuthService(TokenGeneratorService tokenGeneratorService)
    {
        _tokenGeneratorService = tokenGeneratorService;
    }

    private static readonly List<User> _users = new();

    public ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            Password = registrationDetails.Password
        };

        _users.Add(user);

        return new(true);
    }

    // Bizda token string sifatida qaytishi majburiy emas, masalan bunaqa model bo'lishi ham mm
    // TokenDetails
    // {
    // UserId
    // Token
    // ExpireTime
    // }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _users.FirstOrDefault(user => user.EmailAddress == loginDetails.EmailAddress && user.Password == loginDetails.Password);
        if (foundUser is null)
            throw new AuthenticationException("Login details are invalid, contact support.");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);
        return new(accessToken);
    }
}