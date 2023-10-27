using BoardsOnFireSdk;

namespace playground.RequestsSamples;
internal static class UsersRequests
{
    internal static async Task RunAsync(BoardsOnFireClient client)
    {
        Console.WriteLine($"Fetch users");
        var users = await client.Users.ListAsync();
        Console.WriteLine($"Fetched users count: {users.Count}");

        Console.WriteLine($"Fetch user by id...");
        var user = await client.Users.GetByIdAsync(users[0].Id);
        Console.WriteLine($"First user LastName: {user!.LastName}");
    }
}