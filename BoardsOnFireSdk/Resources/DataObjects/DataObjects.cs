namespace BoardsOnFireSdk.Resources.DataObjects;

/// <summary>
/// Resource for list, get, create, update, import and delete data objects
/// </summary>
public class DataObjects : BaseBofObjectsResource
{
    private static string Endpoint(string dataSourceName) => $"datasources/{dataSourceName}/dataobjects";

    public DataObjects(HttpClient httpClient) : base(httpClient)
    {
    }

    public new async Task<TResponseDto?> GetByIdAsync<TResponseDto>(string dataSourceName, Guid id) where TResponseDto : IDataObjectResponseDto
    {
        var endpoint = Endpoint(dataSourceName);
        return await base.GetByIdAsync<TResponseDto>(endpoint, id);
    }

    public new async Task<List<TResponseDto>> ListAsync<TResponseDto>(string dataSourceName, ListQuery query) where TResponseDto : IDataObjectResponseDto
    {
        var endpoint = Endpoint(dataSourceName);
        return await base.ListAsync<TResponseDto>(endpoint, query);
    }

    public new async Task<TResponseDto?> CreateAsync<TRequestDto, TResponseDto>(string dataSourceName, TRequestDto requestDto)
        where TResponseDto : IDataObjectResponseDto
        where TRequestDto : IDataObjectRequestDto
    {
        var endpoint = Endpoint(dataSourceName);
        return await base.CreateAsync<TRequestDto, TResponseDto>(endpoint, requestDto);
    }

    public new async Task<TResponseDto?> PatchAsync<TRequestDto, TResponseDto>(string dataSourceName, Guid id, TRequestDto requestDto)
        where TResponseDto : IDataObjectResponseDto
        where TRequestDto : IDataObjectRequestDto
    {
        var endpoint = Endpoint(dataSourceName);
        return await base.PatchAsync<TRequestDto, TResponseDto>(endpoint, id, requestDto);
    }

    public new async Task<List<Guid>> ImportAsync<TRequestDto>(string dataSourceName, List<TRequestDto> requestDtos) where TRequestDto : IDataObjectRequestDto
    {
        var endpoint = Endpoint(dataSourceName);
        return await base.ImportAsync(endpoint, requestDtos);
    }

    public new async Task DeleteAsync(string dataSourceName, Guid id)
    {
        var endpoint = Endpoint(dataSourceName);
        await base.DeleteAsync(endpoint, id);
    }
}