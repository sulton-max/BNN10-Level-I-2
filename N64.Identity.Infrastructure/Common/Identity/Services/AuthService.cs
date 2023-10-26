using System.Security.Authentication;
using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Domain.Entities;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHasherService _passwordHasherService;

    public AuthService(ITokenGeneratorService tokenGeneratorService, IPasswordHasherService passwordHasherService)
    {
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHasherService = passwordHasherService;
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
            Password = _passwordHasherService.HashPassword(registrationDetails.Password)
        };

        _users.Add(user);

        return new(true);
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _users.FirstOrDefault(user => user.EmailAddress == loginDetails.EmailAddress && user.Password == loginDetails.Password);
        if (foundUser is null)
            throw new AuthenticationException("Login details are invalid, contact support.");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);
        return new(accessToken);
    }
}