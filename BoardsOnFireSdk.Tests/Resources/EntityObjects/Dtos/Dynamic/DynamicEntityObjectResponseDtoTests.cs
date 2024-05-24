using BoardsOnFireSdk.Resources.EntityObjects.Dtos.Dynamic;
using System.Text.Json.Nodes;

namespace BoardsOnFireSdk.Tests.Resources.EntityObjects.Dtos.Dynamic;
public class DynamicEntityObjectResponseDtoTests
{
    [Fact]
    public void CreateDynamicEntityObjectResponseDto_ReturnsDynamicEntityObjectResponseDto()
    {
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow.AddDays(-3);
        var updatedAt = DateTime.UtcNow;
        var archivedAt = DateTime.UtcNow.AddDays(-1);
        var externalId = "Test External Id";

        var organizationId = Guid.NewGuid();
        var organizationName = "Test Organization";
        var organization = new JsonObject
        {
            { "id", organizationId.ToString() },
            { "name", organizationName }
        };

        var createdBy = new JsonObject
        {
            { "id", Guid.NewGuid().ToString() },
            { "first_name", "John" },
            { "last_name", "Doe" },
            { "email", "john.doe@boardsonfiredotnetsdk.com" }
        };

        var responseDictionary = new Dictionary<string, object?>
        {
            { "id", id },
            { "created_at", createdAt },
            { "updated_at", updatedAt },
            { "archived_at", archivedAt },
            { "external_id", externalId },
            { "organization", organization },
            { "test_property1", "Test Value 1" },
            { "test_property2", "Test Value 2" },
            { "bof_created_by", createdBy }
        };

        var result = new DynamicEntityObjectResponseDto(responseDictionary);

        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.NotNull(result.CreatedAt);
        Assert.Equal(createdAt.Date, result.CreatedAt.Value.Date);
        Assert.NotNull(result.UpdatedAt);
        Assert.Equal(updatedAt.Date, result.UpdatedAt.Value.Date);
        Assert.NotNull(result.ArchivedAt);
        Assert.Equal(archivedAt.Date, result.ArchivedAt.Value.Date);
        Assert.Equal(externalId, result.ExternalId);
        Assert.NotNull(result.Organization);
        Assert.Equal(organizationId, result.Organization.Id);
        Assert.Equal(organizationName, result.Organization.Name);
        Assert.Equal(responseDictionary["test_property1"], result.DataProperties["test_property1"]);
        Assert.Equal(responseDictionary["test_property2"], result.DataProperties["test_property2"]);

        Assert.NotNull(result.BofCreatedBy);
        Assert.Equal(createdBy["id"]!.ToString(), result.BofCreatedBy.Id.ToString());
        Assert.Equal(createdBy["first_name"]!.ToString(), result.BofCreatedBy.FirstName);
        Assert.Equal(createdBy["last_name"]!.ToString(), result.BofCreatedBy.LastName);
        Assert.Equal(createdBy["email"]!.ToString(), result.BofCreatedBy.Email);
    }
}
