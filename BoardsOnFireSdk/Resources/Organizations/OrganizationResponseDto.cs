namespace BoardsOnFireSdk.Resources.Organizations;
public class OrganizationResponseDto : OrganizationBaseResponseDto
{
    public Guid? ParentId { get; set; }
    public string? ExternalId { get; set; }
    public string? AvatarColor { get; set; }
}
