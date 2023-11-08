using Microsoft.EntityFrameworkCore;
using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Domain.Entities;
using N64.Identity.Domain.Enums;
using N64.Identity.Persistence.Repositories.Interfaces;

namespace N64.Identity.Infrastructure.Common.Identity.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async ValueTask<Role?> GetByTypeAsync(RoleType roleType)
    {
        return await _roleRepository.Get(role => role.Type == roleType).FirstOrDefaultAsync();
    }
}