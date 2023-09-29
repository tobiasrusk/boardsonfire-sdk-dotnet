namespace BoardsOnFireSdk.Resources.Organizations;
public class OrganizationDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid? ParentId { get; set; }
    public string? ExternalId { get; set; }
    public string? AvatarColor { get; set; }
}
