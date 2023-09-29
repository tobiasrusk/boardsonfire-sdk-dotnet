namespace BoardsOnFireSdk.Resources;
public class ListQuery
{
    /// <summary>
    /// Number of items to fetch per page
    /// </summary>
    public int PageSize { get; set; }
    /// <summary>
    /// Page to fetch
    /// </summary>
    public int Page { get; set; }
    /// <summary>
    /// Sort order and directio, by property and asc/desc
    /// </summary>
    public string? Order { get; set; }
    /// <summary>
    /// Advanced filters
    /// </summary>
    public string? Filter { get; set; }
    /// <summary>
    /// Select statement
    /// </summary>
    public string? Select { get; set; }
    /// <summary>
    /// Group by
    /// </summary>
    public string? Group { get; set; }

    public ListQuery(int pageSize, int page, string? order, string? filter, string? select, string? group)
    {
        PageSize = pageSize;
        Page = page;
        Order = order;
        Filter = filter;
        Select = select;
        Group = group;
    }
}
