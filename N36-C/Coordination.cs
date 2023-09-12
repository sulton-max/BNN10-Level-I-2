namespace N36_C;

public struct Coordination
{
    public int PointX { get; set; }
    public int PointY { get; set; }

    public Coordination(int pointX, int pointY)
    {
        PointX = pointX;
        PointY = pointY;
    }
}

public struct SearchResult
{
    public int ItemId { get; set; }
    public int ItemCategoryId { get; set; }
    public int MatchScore { get; set; }
}