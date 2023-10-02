using BoardsOnFireSdk.Resources.DataObjects;

namespace playground.Entities;

/// <summary>
/// Example with default Status Data Source from Boards on Fire
/// </summary>

public static class SafetyCrossDataSource
{
    public const string DataSourceName = "safety_cross";
}
public class SafetyCrossDataFields
{
    public float? Status { get; set; }
}
public class SafetyCrossDataObjectResponseDto : SafetyCrossDataFields, IDataObjectResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string? Comment { get; set; }
}

public class SafetyCrossDataObjectRequestDto : SafetyCrossDataFields, IDataObjectRequestDto
{
    public Guid OrganizationId { get; set; }
    public DateTime Timestamp { get; set; }
    public string? GroupName { get; set; }
    public string? Comment { get; set; }
}