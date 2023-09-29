namespace BoardsOnFireSdk.Authorization;
public interface IBoardsOnFireAuthorization
{
    /// <summary>
    /// Adds credentials to HTTP client
    /// </summary>
    public abstract void ApplyTo(HttpClient httpClient);
}