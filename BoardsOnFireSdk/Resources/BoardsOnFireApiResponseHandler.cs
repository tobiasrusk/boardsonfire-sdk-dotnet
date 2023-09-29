using BoardsOnFireSdk.Exceptions;
using BoardsOnFireSdk.Serialization;
using System.Net.Http.Json;
using System.Text.Json;

namespace BoardsOnFireSdk.Resources;
public static class BoardsOnFireApiResponseHandler
{
    public static async Task<T?> Handle<T>(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            try
            {
                return await response.Content.ReadFromJsonAsync<T>(DefaultJsonSerializerOptions.Instance);
            }
            catch(JsonException jsonException)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                throw new BoardsOnFireDeserializationException("Failed to parse response json", responseContent, jsonException);
            }
        }

        var content = await response.Content.ReadAsStringAsync();
        throw new BoardsOnFireApiException(response.StatusCode, "Unsuccessful request", content);
    }
}
