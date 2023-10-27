using BoardsOnFireSdk.Resources.Organizations;
using System.Text.Json.Nodes;

namespace BoardsOnFireSdk.Extensions;
public static class DictionaryExtensions
{
    public static Guid? ParseGuid(this Dictionary<string, object?> dictionary, string propertyName)
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

    public static DateTime? ParseDateTime(this Dictionary<string, object?> dictionary, string propertyName)
    {
        var keyName = propertyName.ToSnakeCase();

        if (dictionary.TryGetValue(keyName, out var value))
        {
            dictionary.Remove(keyName);

            var valueAsString = value?.ToString();
            if (valueAsString != null)
            {
                return DateTime.SpecifyKind(DateTime.Parse(valueAsString), DateTimeKind.Utc);
            }
        }

        return null;
    }

    public static OrganizationBaseResponseDto? ParseOrganization(this Dictionary<string, object?> dictionary, string propertyName)
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

    public static string? ParseString(this Dictionary<string, object?> dictionary, string propertyName)
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