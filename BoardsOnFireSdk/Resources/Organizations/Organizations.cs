using BoardsOnFireSdk.Enums;

namespace BoardsOnFireSdk.Resources.Organizations;

/// <summary>
/// Resource for list and get organizations
/// </summary>
public class Organizations : BaseResource<OrganizationDto>
{
    public Organizations(HttpClient httpClient) : base(httpClient, nameof(Organizations).ToLower())
    {
    }

    public async Task<List<OrganizationDto>> ListAsync(int pageSize = 50, int page = 1, Direction direction = Direction.Asc, string order = nameof(OrganizationDto.Name))
    {
        var queryParams = new ListQueryParams(pageSize, page, direction, order);

        return await base.ListAsync(queryParams);
    }

    public override async Task<OrganizationDto?> GetByIdAsync(Guid id)
    {
        return await base.GetByIdAsync(id);
    }
}