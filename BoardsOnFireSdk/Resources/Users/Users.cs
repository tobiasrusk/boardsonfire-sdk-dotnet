using BoardsOnFireSdk.Enums;

namespace BoardsOnFireSdk.Resources.Users;
public class Users : BaseResource<UserDto>
{
    public Users(HttpClient httpClient) : base(httpClient, nameof(Users).ToLower())
    {

    }

    public async Task<List<UserDto>> ListAsync(int pageSize = 50, int page = 1, Direction direction = Direction.Asc, string order = nameof(UserDto.LastName))
    {
        var queryParams = new ListQueryParams(pageSize, page, direction, order);

        return await base.ListAsync(queryParams);
    }

    public override async Task<UserDto?> GetByIdAsync(Guid id)
    {
        return await base.GetByIdAsync(id);
    }
}
