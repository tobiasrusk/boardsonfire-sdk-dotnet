using BoardsOnFireSdk.Resources.DataObjects;

namespace playground.Entities;

/// <summary>
/// Example with default Status Data Source from Boards on Fire
/// </summary>
public class SafetyCrossDataFields
{
    public float? Status { get; set; }
}
public class SafetyCrossDataObjectDto : SafetyCrossDataFields, IDataObjectDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Comment { get; set; }
}

public class SafetyCrossDataObjectCreate : SafetyCrossDataFields, IDataObjectCreate
{
    public Guid OrganizationId { get; set; }
    public DateTime Timestamp { get; set; }
    public string? GroupName { get; set; }
    public string? Comment { get; set; }
}