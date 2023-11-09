using N64.Identity.Application.Common.Enums;
using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Application.Common.Notfications.Services;
using N64.Identity.Domain.Entities;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IVerificationTokenGeneratorService _verificationTokenGeneratorService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    private readonly IUserService _userService;

    public AccountService(
        IVerificationTokenGeneratorService verificationTokenGeneratorService,
        IEmailOrchestrationService emailOrchestrationService,
        IUserService userService
    )
    {
        _verificationTokenGeneratorService = verificationTokenGeneratorService;
        _emailOrchestrationService = emailOrchestrationService;
        _userService = userService;
    }

    public ValueTask<bool> VerificateAsync(string token, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(token))
            throw new ArgumentException("Invalid verification token", nameof(token));

        var verificationTokenResult = _verificationTokenGeneratorService.DecodeToken(token);

        if (!verificationTokenResult.IsValid)
            throw new InvalidOperationException("Invalid verification token");

        var result = verificationTokenResult.Token.Type switch
        {
            VerificationType.EmailAddressVerification => MarkEmailAsVerifiedAsync(verificationTokenResult.Token.UserId),
            _ => throw new InvalidOperationException("This method is not intended to accept other types of tokens")
        };

        return result;
    }

    public async ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        var createdUser = await _userService.CreateAsync(user, true, cancellationToken);

        var verificationToken =
            _verificationTokenGeneratorService.GenerateToken(VerificationType.EmailAddressVerification, createdUser.Id);

        var verificationEmailResult = await _emailOrchestrationService.SendAsync(createdUser.EmailAddress,
            $"Sistemaga xush kelibsiz - {verificationToken}");

        var result = verificationEmailResult; 

        return result;
    }

    public ValueTask<bool> MarkEmailAsVerifiedAsync(Guid userId)
    {
        // var foundUser = _users.FirstOrDefault(user => user.Id == userId) ?? throw new InvalidOperationException();

        // foundUser.IsEmailAddressVerified = true;

        return new(true);
    }
}