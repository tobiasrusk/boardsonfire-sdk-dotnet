namespace BoardsOnFireSdk.Resources.EntityObjects;

/// <summary>
/// Resource for list, get, create, update, import and delete entity objects
/// </summary>
public class EntityObjects : BaseBofObjectsResource
{
    private static string Endpoint(string entityName) => $"entities/{entityName}/entityobjects";

    public EntityObjects(HttpClient httpClient) : base(httpClient)
    {
    }

    public new async Task<TDynamicDto?> GetByIdAsync<TDynamicDto>(string entityName, Guid id) where TDynamicDto : IEntityObjectResponseDto
    {
        var endpoint = Endpoint(entityName);
        return await base.GetByIdAsync<TDynamicDto>(endpoint, id);
    }

    public new async Task<List<TDynamicDto>> ListAsync<TDynamicDto>(string entityName, ListQuery query) where TDynamicDto : IEntityObjectResponseDto
    {
        var endpoint = Endpoint(entityName);
        return await base.ListAsync<TDynamicDto>(endpoint, query);
    }

    public new async Task<TResponseDto?> CreateAsync<TRequestDto, TResponseDto>(string entityName, TRequestDto requestDto) 
        where TResponseDto : IEntityObjectResponseDto 
        where TRequestDto : IEntityObjectRequestDto
    {
        var endpoint = Endpoint(entityName);
        return await base.CreateAsync<TRequestDto, TResponseDto>(endpoint, requestDto);
    }

    public new async Task<TResponseDto?> PatchAsync<TRequestDto, TResponseDto>(string entityName, Guid id, TRequestDto requestDto)
        where TResponseDto : IEntityObjectResponseDto
        where TRequestDto : IEntityObjectRequestDto
    {
        var endpoint = Endpoint(entityName);
        return await base.PatchAsync<TRequestDto, TResponseDto>(endpoint, id, requestDto);
    }

    public new async Task<List<Guid>> ImportAsync<TRequestDto>(string entityName, List<TRequestDto> requestDtos) where TRequestDto : IEntityObjectRequestDto
    {
        var endpoint = Endpoint(entityName);
        return await base.ImportAsync(endpoint, requestDtos);
    }

    public new async Task DeleteAsync(string entityName, Guid id)
    {
        var endpoint = Endpoint(entityName);
        await base.DeleteAsync(endpoint, id);
    }
}