using BoardsOnFireSdk.Enums;
using BoardsOnFireSdk.Resources;

namespace BoardsOnFireSdk.Tests.QueryParams;
public class ListQueryParamsTests
{
    [Theory]
    [InlineData(60, 2, Direction.Asc, null, "page_size=60&page=2&direction=asc")]
    [InlineData(60, 2, Direction.Asc, "ExternalId", "page_size=60&page=2&direction=asc&order=external_id")]
    public void ToString_ReturnsQueryParamString(int pageSize, int page, Direction direction, string? order, string expected)
    {
        var queryParams = new ListQueryParams(pageSize, page, direction, order);
        var queryString = queryParams.ToString();

        Assert.Equal(expected, queryString);
    }
}
