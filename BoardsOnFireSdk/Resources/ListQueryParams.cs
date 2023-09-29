using BoardsOnFireSdk.Enums;
using BoardsOnFireSdk.Extensions;
using System.Text;

namespace BoardsOnFireSdk.Resources;
public class ListQueryParams
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
    /// Sort direction
    /// </summary>
    public Direction Direction { get; set; }
    /// <summary>
    /// Sort order, by property
    /// </summary>
    public string? Order { get; set; }

    public ListQueryParams(int pageSize, int page, Direction direction, string? order)
    {
        PageSize = pageSize;
        Page = page;
        Direction = direction;
        Order = order;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"{nameof(PageSize).ToSnakeCase()}={PageSize}&{nameof(Page).ToSnakeCase()}={Page}&{nameof(Direction).ToSnakeCase()}={Direction.ToString().ToLower()}");

        if (!string.IsNullOrWhiteSpace(Order))
        {
            stringBuilder.Append($"&{nameof(Order).ToSnakeCase()}={Order.ToSnakeCase()}");
        }

        return stringBuilder.ToString();
    }
}
