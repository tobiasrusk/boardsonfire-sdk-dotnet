using BoardsOnFireSdk.Resources.DataObjects.Dtos.Dynamic;

namespace BoardsOnFireSdk.Tests.Resources.DataObjects.Dtos.Dynamic;
public class DynamicDataObjectRequestDtoTests
{
    [Fact]
    public void ToDictionary_ReturnsDictionary()
    {
        var dto = new DynamicDataObjectRequestDto
        {
            OrganizationId = Guid.NewGuid(),
            Timestamp = DateTime.UtcNow,
            GroupName = "Test Group",
            Comment = "Test Comment",
            DataProperties = new Dictionary<string, object?>
            {
                { "test_property1", "Test Value 1" },
                { "test_property2", "Test Value 2" }
            }
        };

        var result = dto.ToDictionary();

        Assert.NotNull(result);
        Assert.True(result.ContainsKey("organization_id"));
        Assert.True(result.ContainsKey("timestamp"));
        Assert.True(result.ContainsKey("group_name"));
        Assert.True(result.ContainsKey("comment"));
        Assert.True(result.ContainsKey("test_property1"));
        Assert.True(result.ContainsKey("test_property2"));

        Assert.Equal(dto.OrganizationId, result["organization_id"]);
        Assert.Equal(dto.Timestamp, result["timestamp"]);
        Assert.Equal(dto.GroupName, result["group_name"]);
        Assert.Equal(dto.Comment, result["comment"]);
        Assert.Equal(dto.DataProperties["test_property1"], result["test_property1"]);
        Assert.Equal(dto.DataProperties["test_property2"], result["test_property2"]);
    }
}
