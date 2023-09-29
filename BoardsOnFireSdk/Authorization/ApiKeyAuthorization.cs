namespace BoardsOnFireSdk.Authorization;
public class ApiKeyAuthorization : IBoardsOnFireAuthorization
{
    private readonly string _apiKey;

    public ApiKeyAuthorization(string apiKey)
    {
        _apiKey = apiKey;
    }

    public void ApplyTo(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
    }
}
