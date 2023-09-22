var listings = new List<ListingCategory>();
listings.Add(new ListingCategory
{
    Name = "Home"
});

public class ListingCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

// ListingFeatureCollection - listing category bilan bog'liq
public class ListingCategoryFeatureCollection
{
    public Guid Id { get; set; }
    public Guid ListingCategoryId { get; set; }
}

// ListingFeature - listing category bilan bog'liq
public class ListingCategoryFeature
{
    public Guid Id { get; set; }
    public Guid ListingCategoryFeatureCollection { get; set; }

    public int MinValue { get; set; }
    public int MaxValue { get; set; }
}

public class ListingFeatureCollection
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class ListingFeature
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}