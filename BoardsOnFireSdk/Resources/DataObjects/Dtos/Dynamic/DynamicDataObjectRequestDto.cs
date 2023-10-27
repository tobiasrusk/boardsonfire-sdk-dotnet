using BoardsOnFireSdk.Extensions;

namespace BoardsOnFireSdk.Resources.DataObjects.Dtos.Dynamic;

/// <summary>
/// Dynamic request dto includes default properties
/// and you add your custom data source properties dynamically to DataProperties
/// </summary>
public class DynamicDataObjectRequestDto : IDataObjectRequestDto
{
    public Guid OrganizationId { get; set; }
    public DateTime Timestamp { get; set; }
    public string? GroupName { get; set; }
    public string? Comment { get; set; }
    public Dictionary<string, object?> DataProperties { get; set; } = new Dictionary<string, object?>();

    public Dictionary<string, object?> ToDictionary()
    {
        var requestModel = new Dictionary<string, object?>
        {
            { nameof(OrganizationId).ToSnakeCase(), OrganizationId },
            { nameof(Timestamp).ToSnakeCase(), Timestamp },
            { nameof(GroupName).ToSnakeCase(), GroupName },
            { nameof(Comment).ToSnakeCase(), Comment }
        };

        foreach (var (key, value) in DataProperties)
        {
            requestModel.Add(key, value);
        }

        return requestModel;
    }
}
