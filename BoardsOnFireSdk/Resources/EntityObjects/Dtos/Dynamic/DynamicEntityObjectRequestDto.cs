using BoardsOnFireSdk.Extensions;

namespace BoardsOnFireSdk.Resources.EntityObjects.Dtos.Dynamic;

/// <summary>
/// Dynamic request dto includes default properties
/// and you add your custom data source properties dynamically to DataProperties
/// </summary>
public class DynamicEntityObjectRequestDto : IEntityObjectRequestDto
{
    public Guid? Id { get; set; }
    public Guid OrganizationId { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public string? ExternalId { get; set; }
    public Dictionary<string, object?> DataProperties { get; set; } = new Dictionary<string, object?>();

    public Dictionary<string, object?> ToDictionary()
    {
        var requestModel = new Dictionary<string, object?>
        {
            { nameof(Id).ToSnakeCase(), Id },
            { nameof(OrganizationId).ToSnakeCase(), OrganizationId },
            { nameof(ArchivedAt).ToSnakeCase(), ArchivedAt },
            { nameof(ExternalId).ToSnakeCase(), ExternalId }
        };

        foreach (var (key, value) in DataProperties)
        {
            requestModel.Add(key, value);
        }

        return requestModel;
    }
}
