using BoardsOnFireSdk;

namespace playground.RequestsSamples;
internal static class UsersRequests
{
    internal static async Task RunAsync(BoardsOnFireClient client)
    {
        var users = await client.Users.ListAsync();
        Console.WriteLine($"Fetched users count: {users.Count}");

        var user = await client.Users.GetByIdAsync(users[0].Id);
        Console.WriteLine($"First user LastName: {user!.LastName}");
    }
}