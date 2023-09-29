using System.Text.Json;
using System.Text.Json.Serialization;

namespace BoardsOnFireSdk.Serialization;

public static class DefaultJsonSerializerOptions
{
    public static JsonSerializerOptions Instance { get; } = new JsonSerializerOptions
    {
        PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance,
        Converters =
        {
            new JsonStringEnumConverter(SnakeCaseNamingPolicy.Instance)
        },
        UnknownTypeHandling = JsonUnknownTypeHandling.JsonNode,
    };
}