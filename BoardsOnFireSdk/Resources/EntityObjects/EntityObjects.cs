using System.Dynamic;

namespace BoardsOnFireSdk.Resources.DataSources;
public class EntityObjects : BaseResource<ExpandoObject>
{
    public EntityObjects(HttpClient httpClient) : base(httpClient, nameof(EntityObjects).ToLower())
    {
    }

    public new async Task<ExpandoObject?> GetByIdAsync(string entityName, Guid id)
    {
        var endpoint = base.EntityObjectsEndpoint(entityName);
        return await base.GetByIdAsync(endpoint, id);
    }

    public new async Task<List<ExpandoObject>> ListAsync(string entityName, ListQuery query)
    {
        var endpoint = base.EntityObjectsEndpoint(entityName);
        return await base.ListAsync(endpoint, query);
    }
}