using BoardsOnFireSdk.Exceptions;
using BoardsOnFireSdk.Resources;
using BoardsOnFireSdk.Resources.Users;
using BoardsOnFireSdk.Serialization;
using System.Net;
using System.Text.Json;

namespace BoardsOnFireSdk.Tests;
public class BoardsOnFireApiResponseHandlerTests
{
    [Fact]
    public async Task Handle_Unsuccessful_ThrowExceptionWithResponseData()
    {
        const string returnMessage = "Invalid endpoint";

        var content = new StringContent(returnMessage);
        var httpResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.NotFound,
            Content = content
        };

        var exception = await Assert.ThrowsAsync<BoardsOnFireApiException>(async () => await BoardsOnFireApiResponseHandler.Handle<UserDto>(httpResponse));

        Assert.NotNull(exception);
        Assert.Equal(HttpStatusCode.NotFound, exception.StatusCode);
        Assert.Equal("Unsuccessful request", exception.Message);
        Assert.Equal(returnMessage, exception.ErrorMessage);
    }

    [Fact]
    public async Task Handle_Successful_ThrowExceptionWithResponseData()
    {
        var user = new UserDto
        {
            Id = Guid.NewGuid(),
            FirstName = "Test",
            LastName = "Test",
            Email = "test.test@boardsonfiretest.com",
            ExternalId = "Test",
            Type = Enums.UserType.User
        };
        var json = JsonSerializer.Serialize(user, DefaultJsonSerializerOptions.Instance);

        var content = new StringContent(json);
        var httpResponse = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = content
        };

        var result = await BoardsOnFireApiResponseHandler.Handle<UserDto>(httpResponse);

        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);
        Assert.Equal(user.FirstName, result.FirstName);
        Assert.Equal(user.LastName, result.LastName);
        Assert.Equal(user.Email, result.Email);
        Assert.Equal(user.ExternalId, result.ExternalId);
        Assert.Equal(user.Type, result.Type);
    }
}