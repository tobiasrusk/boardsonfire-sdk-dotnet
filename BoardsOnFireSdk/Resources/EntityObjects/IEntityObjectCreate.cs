namespace BoardsOnFireSdk.Resources.EntityObjects;

/// <summary>
/// Default fields for create entity object. Create implementation with your custom fields.
/// </summary>
public interface IEntityObjectCreate
{
    public Guid OrganizationId { get; set; }
}
