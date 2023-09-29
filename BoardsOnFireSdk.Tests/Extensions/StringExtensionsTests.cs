using BoardsOnFireSdk.Extensions;

namespace BoardsOnFireSdk.Tests.Extensions;
public class StringExtensionsTests
{
    [Theory]
    [InlineData("BoardsOnFire", "boards_on_fire")]
    [InlineData("boardsonFire", "boardson_fire")]
    public void ToSnakeCase_OK(string input, string expected)
    {
        var actual = input.ToSnakeCase();
        Assert.Equal(expected, actual);
    }
}