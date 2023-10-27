using BoardsOnFireSdk.Extensions;
using BoardsOnFireSdk.Resources.Organizations;

namespace BoardsOnFireSdk.Resources.DataObjects.Dtos.Dynamic;

/// <summary>
/// Dynamic response dto includes default properties
/// and you add your custom data source properties dynamically to DataProperties
/// </summary>
public class DynamicDataObjectResponseDto : IDataObjectResponseDto
{
    public DynamicDataObjectResponseDto(Dictionary<string, object?> responseDictionary)
    {
        Id = responseDictionary.ParseGuid(nameof(Id));
        CreatedAt = responseDictionary.ParseDateTime(nameof(CreatedAt));
        UpdatedAt = responseDictionary.ParseDateTime(nameof(UpdatedAt));
        Organization = responseDictionary.ParseOrganization(nameof(Organization));
        Comment = responseDictionary.ParseString(nameof(Comment));

        DataProperties = responseDictionary;
    }

    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Comment { get; set; }
    public OrganizationBaseResponseDto? Organization { get; set; }
    public Dictionary<string, object?> DataProperties { get; set; }
}
