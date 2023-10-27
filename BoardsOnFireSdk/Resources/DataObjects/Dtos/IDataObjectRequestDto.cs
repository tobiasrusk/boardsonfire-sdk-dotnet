namespace BoardsOnFireSdk.Resources.DataObjects.Dtos;

/// <summary>
/// Default fields for create data object. Create implementation with your custom fields.
/// </summary>
public interface IDataObjectRequestDto
{
    public Guid OrganizationId { get; set; }
    public DateTime Timestamp { get; set; }
    public string? GroupName { get; set; }
    public string? Comment { get; set; }
}
