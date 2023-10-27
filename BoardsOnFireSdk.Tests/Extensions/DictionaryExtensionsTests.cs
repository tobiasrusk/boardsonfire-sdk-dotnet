using BoardsOnFireSdk.Extensions;
using System.Text.Json.Nodes;

namespace BoardsOnFireSdk.Tests.Extensions;
public class DictionaryExtensionsTests
{
    [Fact]
    public void ParseGuid_ReturnGuid()
    {
        var dictionary = new Dictionary<string, object?>
        {
            { "id", Guid.NewGuid() }
        };

        var actual = dictionary.ParseGuid("Id");
        Assert.NotNull(actual);
        Assert.False(dictionary.ContainsKey("id"));
    }

    [Fact]
    public void ParseGuid_ReturnNull()
    {
        var dictionary = new Dictionary<string, object?>
        {
            { "id", Guid.NewGuid() }
        };

        var actual = dictionary.ParseGuid("OrganizationId");
        Assert.Null(actual);
        Assert.True(dictionary.ContainsKey("id"));
    }

    [Fact]
    public void ParseDateTime_ReturnDateTime()
    {
        var dictionary = new Dictionary<string, object?>
        {
            { "created_at", DateTime.UtcNow }
        };

        var actual = dictionary.ParseDateTime("CreatedAt");
        Assert.NotNull(actual);
        Assert.False(dictionary.ContainsKey("created_at"));
    }

    [Fact]
    public void ParseDateTime_ReturnNull()
    {
        var dictionary = new Dictionary<string, object?>
        {
            { "created_at", DateTime.UtcNow }
        };

        var actual = dictionary.ParseDateTime("UpdatedAt");
        Assert.Null(actual);
        Assert.True(dictionary.ContainsKey("created_at"));
    }

    [Fact]
    public void ParseOrganization_ReturnOrganization()
    {
        var organizationId = Guid.NewGuid().ToString();
        var organizationName = "BoardsOnFire";
        var dictionary = new Dictionary<string, object?>
        {
            { "organization", new JsonObject
                {
                    { "id", organizationId },
                    { "name", organizationName }
                }
            }
        };

        var actual = dictionary.ParseOrganization("Organization");
        Assert.NotNull(actual);
        Assert.Equal(organizationId, actual.Id.ToString());
        Assert.Equal(organizationName, actual.Name);
        Assert.False(dictionary.ContainsKey("organization"));
    }

    [Fact]
    public void ParseOrganization_ReturnNull()
    {
        var organizationId = Guid.NewGuid().ToString();
        var organizationName = "BoardsOnFire";
        var dictionary = new Dictionary<string, object?>
        {
            { "organization", new JsonObject
                {
                    { "id", organizationId },
                    { "name", organizationName }
                }
            }
        };

        var actual = dictionary.ParseOrganization("OtherOrganization");
        Assert.Null(actual);
        Assert.True(dictionary.ContainsKey("organization"));
    }

    [Fact]
    public void ParseString_ReturnString()
    {
        var dictionary = new Dictionary<string, object?>
        {
            { "external_id", "hello123" }
        };

        var actual = dictionary.ParseString("ExternalId");
        Assert.NotNull(actual);
        Assert.False(dictionary.ContainsKey("external_id"));
    }

    [Fact]
    public void ParseString_ReturnNull()
    {
        var dictionary = new Dictionary<string, object?>
        {
            { "external_id", "hello123" }
        };

        var actual = dictionary.ParseString("InternalId");
        Assert.Null(actual);
        Assert.True(dictionary.ContainsKey("external_id"));
    }
}