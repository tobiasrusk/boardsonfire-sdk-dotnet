using BoardsOnFireSdk.Enums;

namespace BoardsOnFireSdk.Resources.Organizations;
public class Organizations : BaseResource
{
    public Organizations(HttpClient httpClient) : base(httpClient, nameof(Organizations).ToLower())
    {
    }

    public async Task<List<OrganizationDto>> ListAsync(int pageSize = 50, int page = 1, Direction direction = Direction.Asc, string order = nameof(OrganizationDto.Name))
    {
        var queryParams = new ListQueryParams(pageSize, page, direction, order);

        return await base.ListAsync<OrganizationDto>(queryParams);
    }
}