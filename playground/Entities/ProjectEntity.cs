using BoardsOnFireSdk.Resources.EntityObjects;

namespace playground.Entities;

/// <summary>
/// Example with default Project Entity from Boards on Fire
/// </summary>
public class ProjectEntityFields
{
    public float? Status { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
public class ProjectEntityObjectDto : ProjectEntityFields, IEntityObjectDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class SafetyCrossEntityObjectCreate : ProjectEntityFields, IEntityObjectCreate
{
    public Guid OrganizationId { get; set; }
}