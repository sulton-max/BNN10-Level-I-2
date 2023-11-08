using System.Security.Authentication;
using N64.Identity.Application.Common.Identity.Models;
using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Application.Common.Notfications.Services;
using N64.Identity.Domain.Entities;
using N64.Identity.Domain.Enums;
using N64.Identity.Persistence.DataContexts;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly IdentityDbContext _dbContext;
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;
    private readonly ITokenGeneratorService _tokenGeneratorService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IAccountService _accountService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;

    public AuthService(
        IdentityDbContext dbContext,
        IRoleService roleService,
        IUserService userService,
        ITokenGeneratorService tokenGeneratorService,
        IPasswordHasherService passwordHasherService,
        IAccountService accountService,
        IEmailOrchestrationService emailOrchestrationService
    )
    {
        _dbContext = dbContext;
        _roleService = roleService;
        _userService = userService;
        _tokenGeneratorService = tokenGeneratorService;
        _passwordHasherService = passwordHasherService;
        _accountService = accountService;
        _emailOrchestrationService = emailOrchestrationService;
    }


    public async ValueTask<bool> RegisterAsync(RegistrationDetails registrationDetails)
    {
        var foundUser = _accountService.Users.FirstOrDefault(user => user.EmailAddress == registrationDetails.EmailAddress);
        if (foundUser is not null)
            throw new InvalidOperationException("User with this email address already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registrationDetails.FirstName,
            LastName = registrationDetails.LastName,
            Age = registrationDetails.Age,
            EmailAddress = registrationDetails.EmailAddress,
            PasswordHash = _passwordHasherService.HashPassword(registrationDetails.Password)
        };

        await _accountService.CreateUserAsync(user);
        var verificationEmailResult = await _emailOrchestrationService.SendAsync(registrationDetails.EmailAddress, "Sistemaga xush kelibsiz");

        return verificationEmailResult;
    }

    public ValueTask<string> LoginAsync(LoginDetails loginDetails)
    {
        var foundUser = _accountService.Users.FirstOrDefault(user => user.EmailAddress == loginDetails.EmailAddress);
        if (foundUser is null || !_passwordHasherService.ValidatePassword(loginDetails.Password, foundUser.PasswordHash))
            throw new AuthenticationException("Login details are invalid, contact support.");

        var accessToken = _tokenGeneratorService.GetToken(foundUser);
        return new(accessToken);
    }

    public async ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, Guid actionUserId)
    {
        var user = await _userService.GetByIdAsync(userId) ?? throw new InvalidOperationException();
        _ = await _userService.GetByIdAsync(actionUserId) ?? throw new InvalidOperationException();
        
        if (!Enum.TryParse(roleType, out RoleType roleValue)) throw new InvalidOperationException();
        var role = await _roleService.GetByTypeAsync(roleValue) ?? throw new InvalidOperationException();

        user.Role = role;
        
        _dbContext.Users.Attach(user);
        _dbContext.Update(user);
        var test = _dbContext.SaveChanges();

        // await _userService.UpdateAsync(user);
        
        return true;
    }
}