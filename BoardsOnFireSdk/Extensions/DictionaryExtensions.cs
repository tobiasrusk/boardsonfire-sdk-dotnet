using BoardsOnFireSdk.Resources.Organizations;
using System.Text.Json.Nodes;

namespace BoardsOnFireSdk.Extensions;
internal static class DictionaryExtensions
{
    internal static Guid? ParseGuid(this Dictionary<string, object?> dictionary, string propertyName)
    {
        var keyName = propertyName.ToSnakeCase();

        if (dictionary.TryGetValue(keyName, out var value))
        {
            dictionary.Remove(keyName);

            var valueAsString = value?.ToString();
            if (valueAsString != null)
            {
                return Guid.Parse(valueAsString);
            }            
        }

        return null;
    }

    internal static DateTime? ParseDateTime(this Dictionary<string, object?> dictionary, string propertyName)
    {
        var keyName = propertyName.ToSnakeCase();

        if (dictionary.TryGetValue(keyName, out var value))
        {
            dictionary.Remove(keyName);

            var valueAsString = value?.ToString();
            if (valueAsString != null)
            {
                return DateTime.Parse(valueAsString);
            }
        }

        return null;
    }

    internal static OrganizationBaseResponseDto? ParseOrganization(this Dictionary<string, object?> dictionary, string propertyName)
    {
        var keyName = propertyName.ToSnakeCase();

        if (dictionary.TryGetValue(keyName, out var value))
        {
            dictionary.Remove(keyName);

            if (value == null)
            {
                return null;
            }

            var jsonObject = (JsonObject)value;
            return new OrganizationBaseResponseDto
            {
                Id = Guid.Parse(jsonObject.FirstOrDefault(x => x.Key == "id").Value!.ToString()),
                Name = jsonObject.FirstOrDefault(x => x.Key == "name").Value!.ToString(),
            };
        }

        return null;
    }

    internal static string? ParseString(this Dictionary<string, object?> dictionary, string propertyName)
    {
        var keyName = propertyName.ToSnakeCase();

        if (dictionary.TryGetValue(keyName, out var value))
        {
            dictionary.Remove(keyName);

            return value?.ToString();
        }

        return null;
    }
}