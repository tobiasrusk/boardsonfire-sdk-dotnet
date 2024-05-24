using BoardsOnFireSdk.Resources.DataObjects.Dtos;
using BoardsOnFireSdk.Resources.Organizations;
using BoardsOnFireSdk.Resources.Users;

namespace playground.Entities;

/// <summary>
/// Example of using DataObjects typed implementation with default Status Data Source from Boards on Fire
/// </summary>

public static class SafetyCrossDataSource
{
    public const string DataSourceName = "safety_cross";
}

public class SafetyCrossDataFields
{
    public float? Status { get; set; }
}

public class SafetyCrossConcreteDataObjectResponseDto : SafetyCrossDataFields, IDataObjectResponseDto
{
    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Comment { get; set; }
    public OrganizationBaseResponseDto? Organization { get; set; }
    public UserCreatedByDto? BofCreatedBy { get; set; }
}

public class SafetyCrossConcreteDataObjectRequestDto : SafetyCrossDataFields, IDataObjectRequestDto
{
    public Guid OrganizationId { get; set; }
    public DateTime Timestamp { get; set; }
    public string? GroupName { get; set; }
    public string? Comment { get; set; }
}