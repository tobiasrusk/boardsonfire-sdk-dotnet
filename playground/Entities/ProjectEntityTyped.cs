using BoardsOnFireSdk.Resources.EntityObjects.Dtos;
using BoardsOnFireSdk.Resources.Organizations;

namespace playground.Entities;

/// <summary>
/// Example with default Project Entity from Boards on Fire
/// </summary>
public static class ProjectEntityTyped
{
    public const string EntityName = "project_entity";
}

public class ProjectEntityFields
{
    public float? Status { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
public class ProjectEntityObjectResponseDto : ProjectEntityFields, IEntityObjectResponseDto
{
    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public string? ExternalId { get; set; }
    public OrganizationBaseResponseDto? Organization { get; set; }
}

public class ProjectEntityObjectRequestDto : ProjectEntityFields, IEntityObjectRequestDto
{
    public Guid? Id { get; set; }
    public Guid OrganizationId { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public string? ExternalId { get; set; }
}

public class ProjectEntityObjectImportRequestDto : EntityObjectImportRequestDto<ProjectEntityObjectRequestDto>
{
}