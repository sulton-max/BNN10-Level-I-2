using N64.Identity.Domain.Entities;
using N64.Identity.Domain.Enums;

namespace N64.Identity.Application.Common.Identity.Services;

public interface IRoleService
{
    ValueTask<Role?> GetByTypeAsync(RoleType roleType);
}