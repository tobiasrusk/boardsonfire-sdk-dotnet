namespace BoardsOnFireSdk.Resources;
public abstract class BaseResource<TDto>
{
    protected HttpClient HttpClient { get; }
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

    protected async Task<List<TDto>> ListAsync(ListQueryParams queryParams)
    {
        using var response = await HttpClient.GetAsync($"{Endpoint}?{queryParams}");

        return await BoardsOnFireApiResponseHandler.Handle<List<TDto>>(response) ?? new List<TDto>();
    }
}