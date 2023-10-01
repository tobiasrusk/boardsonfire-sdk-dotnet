using BoardsOnFireSdk.Serialization;
using System.Net.Http.Json;

namespace BoardsOnFireSdk.Resources;
public abstract class BaseResource<TDto>
{
    protected HttpClient HttpClient { get; }
    protected string DataObjectsEndpoint(string dataSourceName) => $"datasources/{dataSourceName}/{Endpoint}";
    protected string EntityObjectsEndpoint(string entityName) => $"entities/{entityName}/{Endpoint}";
    private string Endpoint { get; }

    protected BaseResource(HttpClient httpClient, string endpoint)
    {
        HttpClient = httpClient;
        Endpoint = endpoint;
    }

    public virtual async Task<TDto?> GetByIdAsync(Guid id)
    {
        using var response = await HttpClient.GetAsync($"{Endpoint}/{id}");

        return await BoardsOnFireApiResponseHandler.Handle<TDto>(response);
    }

    protected async Task<TDynamicDto?> GetByIdAsync<TDynamicDto>(string endpoint, Guid id)
    {
        using var response = await HttpClient.GetAsync($"{endpoint}/{id}");

        return await BoardsOnFireApiResponseHandler.Handle<TDynamicDto>(response);
    }

    protected async Task<List<TDto>> ListAsync(ListQueryParams queryParams)
    {
        using var response = await HttpClient.GetAsync($"{Endpoint}?{queryParams}");

        return await BoardsOnFireApiResponseHandler.Handle<List<TDto>>(response) ?? new List<TDto>();
    }

    protected async Task<List<TDynamicDto>> ListAsync<TDynamicDto>(string endpoint, ListQuery query)
    {
        using var response = await HttpClient.PostAsJsonAsync($"{endpoint}/list", query, DefaultJsonSerializerOptions.Instance);

        return await BoardsOnFireApiResponseHandler.Handle<List<TDynamicDto>>(response) ?? new List<TDynamicDto>();
    }
}