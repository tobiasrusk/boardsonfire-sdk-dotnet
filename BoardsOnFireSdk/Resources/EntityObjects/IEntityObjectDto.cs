namespace BoardsOnFireSdk.Resources.EntityObjects;

/// <summary>
/// Default fields for entity object. Create implementation with your custom fields.
/// </summary>
public interface IEntityObjectDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}