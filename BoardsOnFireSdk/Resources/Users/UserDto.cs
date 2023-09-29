using BoardsOnFireSdk.Enums;

namespace BoardsOnFireSdk.Resources.Users;
public class UserDto
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? ExternalId { get; set; }
    public UserType Type { get; set; }
}