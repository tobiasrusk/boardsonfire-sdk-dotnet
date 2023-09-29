namespace BoardsOnFireSdk;
internal static class BoardsOnFireApiConstants
{
    /// <summary>
    /// Base Uri to Boards on Fire API
    /// </summary>
    internal static string BoardsOnFireApiBaseUri(string customerEndpoint, int apiVersion) => $"https://{customerEndpoint}.boardsonfirestaging.com/api/v{apiVersion}/";

    /// <summary>
    /// Default API version
    /// </summary>
    internal const int DefaultApiVersion = 5;

    /// <summary>
    /// Max page size that can be returned by the API
    /// </summary>
    internal const int MaxPageSize = 500;
}
