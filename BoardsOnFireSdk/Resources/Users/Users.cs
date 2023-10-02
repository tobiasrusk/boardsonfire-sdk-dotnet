using BoardsOnFireSdk.Enums;

namespace BoardsOnFireSdk.Resources.Users;

/// <summary>
/// Resource for list and get users
/// </summary>
public class Users : BaseResource<UserResponseDto>
{
    public Users(HttpClient httpClient) : base(httpClient, nameof(Users).ToLower())
    {

    }

    public async Task<List<UserResponseDto>> ListAsync(int pageSize = 50, int page = 1, Direction direction = Direction.Asc, string order = nameof(UserResponseDto.LastName))
    {
        var queryParams = new ListQueryParams(pageSize, page, direction, order);

        return await base.ListAsync(queryParams);
    }

    public override async Task<UserResponseDto?> GetByIdAsync(Guid id)
    {
        return await base.GetByIdAsync(id);
    }
}
