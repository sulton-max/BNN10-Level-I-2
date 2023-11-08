using N64.Identity.Domain.Common;
using N64.Identity.Domain.Enums;

namespace N64.Identity.Domain.Entities;

public class Role : IEntity
{
    public Guid Id { get; set; }

    public RoleType Type { get; set; }
    
    public bool IsDisabled { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime ModifiedTime { get; set; }
}