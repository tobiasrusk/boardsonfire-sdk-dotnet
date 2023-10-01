using BoardsOnFireSdk.Resources.EntityObjects;

namespace BoardsOnFireSdk.Resources.DataSources;

/// <summary>
/// Resource for list, get, create, update, import and delete entity objects
/// </summary>
public class EntityObjects : BaseResource<IEntityObjectDto>
{
    public EntityObjects(HttpClient httpClient) : base(httpClient, nameof(EntityObjects).ToLower())
    {
    }

    public new async Task<TDynamicDto?> GetByIdAsync<TDynamicDto>(string entityName, Guid id) where TDynamicDto : IEntityObjectDto
    {
        var endpoint = base.EntityObjectsEndpoint(entityName);
        return await base.GetByIdAsync<TDynamicDto>(endpoint, id);
    }

    public new async Task<List<TDynamicDto>> ListAsync<TDynamicDto>(string entityName, ListQuery query) where TDynamicDto : IEntityObjectDto
    {
        var endpoint = base.EntityObjectsEndpoint(entityName);
        return await base.ListAsync<TDynamicDto>(endpoint, query);
    }
}