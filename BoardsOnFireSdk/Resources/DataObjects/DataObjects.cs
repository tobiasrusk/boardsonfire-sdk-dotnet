using BoardsOnFireSdk.Resources.DataObjects;

namespace BoardsOnFireSdk.Resources.DataSources;

/// <summary>
/// Resource for list, get, create, update, import and delete data objects
/// </summary>
public class DataObjects : BaseResource<IDataObjectDto>
{
    public DataObjects(HttpClient httpClient) : base(httpClient, nameof(DataObjects).ToLower())
    {
    }

    public new async Task<TDynamicDto?> GetByIdAsync<TDynamicDto>(string dataSourceName, Guid id) where TDynamicDto : IDataObjectDto
    {
        var endpoint = base.DataObjectsEndpoint(dataSourceName);
        return await base.GetByIdAsync<TDynamicDto>(endpoint, id);
    }

    public new async Task<List<TDynamicDto>> ListAsync<TDynamicDto>(string dataSourceName, ListQuery query) where TDynamicDto : IDataObjectDto
    {
        var endpoint = base.DataObjectsEndpoint(dataSourceName);
        return await base.ListAsync<TDynamicDto>(endpoint, query);
    }
}