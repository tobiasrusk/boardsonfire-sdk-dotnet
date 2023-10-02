using BoardsOnFireSdk.Enums;

namespace BoardsOnFireSdk.Resources.Organizations;

/// <summary>
/// Resource for list and get organizations
/// </summary>
public class Organizations : BaseResource<OrganizationResponseDto>
{
    public Organizations(HttpClient httpClient) : base(httpClient, nameof(Organizations).ToLower())
    {
    }

    public async Task<List<OrganizationResponseDto>> ListAsync(int pageSize = 50, int page = 1, Direction direction = Direction.Asc, string order = nameof(OrganizationResponseDto.Name))
    {
        var queryParams = new ListQueryParams(pageSize, page, direction, order);

        return await base.ListAsync(queryParams);
    }

    public override async Task<OrganizationResponseDto?> GetByIdAsync(Guid id)
    {
        return await base.GetByIdAsync(id);
    }
}