namespace BoardsOnFireSdk.Resources.Users;
public class UserCreatedByDto
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? AvatarColor { get; set; }
}
