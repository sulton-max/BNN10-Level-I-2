using N64.Identity.Domain.Entities;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IAccountService
{
    List<User> Users { get; }

    ValueTask<bool> VerificateAsync(string token);

    ValueTask<User> CreateUserAsync(User user);
}