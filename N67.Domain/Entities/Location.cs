namespace N67.Domain.Entities;

public class Location
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    
    public LocationType Type { get; set; }
    
    public Guid? ParentId { get; set; }
    
    public virtual ICollection<Location> ChildrenLocations { get; set; }
    
    public virtual Location ParentLocation { get; set; } 
}