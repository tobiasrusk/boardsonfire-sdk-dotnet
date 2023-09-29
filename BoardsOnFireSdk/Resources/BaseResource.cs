namespace BoardsOnFireSdk.Resources;
public abstract class BaseResource
{
    protected HttpClient HttpClient { get; }
    private string Endpoint { get; }

    protected BaseResource(HttpClient httpClient, string endpoint)
    {
        HttpClient = httpClient;
        Endpoint = endpoint;
    }

    protected async Task<List<T>> ListAsync<T>(ListQueryParams queryParams)
    {
        using var response = await HttpClient.GetAsync($"{Endpoint}?{queryParams}");

        return await BoardsOnFireApiResponseHandler.Handle<List<T>>(response) ?? new List<T>();
    }
}