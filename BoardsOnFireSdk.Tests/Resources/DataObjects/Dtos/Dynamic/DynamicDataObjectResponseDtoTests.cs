using BoardsOnFireSdk.Resources.DataObjects.Dtos.Dynamic;
using System.Text.Json.Nodes;

namespace BoardsOnFireSdk.Tests.Resources.DataObjects.Dtos.Dynamic;
public class DynamicDataObjectResponseDtoTests
{
    [Fact]
    public void CreateDynamicDataObjectResponseDto_ReturnsDynamicDataObjectResponseDto()
    {
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow.AddDays(-3);
        var updatedAt = DateTime.UtcNow;
        var comment = "Test comment";

        var organizationId = Guid.NewGuid();
        var organizationName = "Test Organization";
        var organization = new JsonObject
        {
            { "id", organizationId.ToString() },
            { "name", organizationName }
        };

        var responseDictionary = new Dictionary<string, object?>
        {
            { "id", id },
            { "created_at", createdAt },
            { "updated_at", updatedAt },
            { "comment", comment },
            { "organization", organization },
            { "test_property1", "Test Value 1" },
            { "test_property2", "Test Value 2" }
        };

        var result = new DynamicDataObjectResponseDto(responseDictionary);

        Assert.NotNull(result);
        Assert.Equal(id, result.Id);
        Assert.NotNull(result.CreatedAt);
        Assert.Equal(createdAt.Date, result.CreatedAt.Value.Date);
        Assert.NotNull(result.UpdatedAt);
        Assert.Equal(updatedAt.Date, result.UpdatedAt.Value.Date);
        Assert.Equal(comment, result.Comment);
        Assert.NotNull(result.Organization);
        Assert.Equal(organizationId, result.Organization.Id);
        Assert.Equal(organizationName, result.Organization.Name);
        Assert.Equal(responseDictionary["test_property1"], result.DataProperties["test_property1"]);
        Assert.Equal(responseDictionary["test_property2"], result.DataProperties["test_property2"]);
    }
}