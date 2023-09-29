using System.Dynamic;

namespace BoardsOnFireSdk.Resources.DataSources;
public class DataObjects : BaseResource<ExpandoObject>
{
    public DataObjects(HttpClient httpClient) : base(httpClient, nameof(DataObjects).ToLower())
    {
    }

    public new async Task<ExpandoObject?> GetByIdAsync(string dataSourceName, Guid id)
    {
        var endpoint = base.DataObjectsEndpoint(dataSourceName);
        return await base.GetByIdAsync(endpoint, id);
    }

    public new async Task<List<ExpandoObject>> ListAsync(string dataSourceName, ListQuery query)
    {
        var endpoint = base.DataObjectsEndpoint(dataSourceName);
        return await base.ListAsync(endpoint, query);
    }
}