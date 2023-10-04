namespace Di.Api.Models.Filters;

public class FilterPagination : FilterBase
{
    public int PageSize { get; set; } = 20;
    public int PageToken { get; set; } = 1;
}