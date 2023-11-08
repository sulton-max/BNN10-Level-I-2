using N64.Identity.Domain.Entities;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IUserService
{
    ValueTask<User?> GetByIdAsync(Guid userId);
    
    ValueTask<User> UpdateAsync(User user);
}