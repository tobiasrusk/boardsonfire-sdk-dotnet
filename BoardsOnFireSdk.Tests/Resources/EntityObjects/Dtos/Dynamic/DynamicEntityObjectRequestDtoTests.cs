using BoardsOnFireSdk.Resources.EntityObjects.Dtos.Dynamic;

namespace BoardsOnFireSdk.Tests.Resources.EntityObjects.Dtos.Dynamic;
public class DynamicEntityObjectRequestDtoTests
{
    [Fact]
    public void ToDictionary_ReturnsDictionary()
    {
        var dto = new DynamicEntityObjectRequestDto
        {
            Id = Guid.NewGuid(),
            OrganizationId = Guid.NewGuid(),
            ArchivedAt = DateTime.UtcNow,
            ExternalId = "Test External Id",
            DataProperties = new Dictionary<string, object?>
            {
                { "test_property1", "Test Value 1" },
                { "test_property2", "Test Value 2" }
            }
        };

        var result = dto.ToDictionary();

        Assert.NotNull(result);
        Assert.True(result.ContainsKey("id"));
        Assert.True(result.ContainsKey("organization_id"));
        Assert.True(result.ContainsKey("archived_at"));
        Assert.True(result.ContainsKey("external_id"));
        Assert.True(result.ContainsKey("test_property1"));
        Assert.True(result.ContainsKey("test_property2"));

        Assert.Equal(dto.Id, result["id"]);
        Assert.Equal(dto.OrganizationId, result["organization_id"]);
        Assert.Equal(dto.ArchivedAt, result["archived_at"]);
        Assert.Equal(dto.ExternalId, result["external_id"]);
        Assert.Equal(dto.DataProperties["test_property1"], result["test_property1"]);
        Assert.Equal(dto.DataProperties["test_property2"], result["test_property2"]);
    }
}
