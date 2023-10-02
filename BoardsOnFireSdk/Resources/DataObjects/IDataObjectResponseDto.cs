namespace BoardsOnFireSdk.Resources.DataObjects;

/// <summary>
/// Default fields for data object. Create implementation with your custom fields.
/// </summary>
public interface IDataObjectResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Comment { get; set; }
}
