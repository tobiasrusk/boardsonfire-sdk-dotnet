using BoardsOnFireSdk;

namespace playground.RequestsSamples;
internal static class OrganizationsRequests
{
    internal static async Task<Guid> RunAndReturnFirstOrganizationidAsync(BoardsOnFireClient client)
    {
        Console.WriteLine($"Fetch organizations...");
        var organizations = await client.Organizations.ListAsync();
        Console.WriteLine($"Fetched organizations count: {organizations.Count}");

        Console.WriteLine($"Fetch organization by id...");
        var organization = await client.Organizations.GetByIdAsync(organizations[0].Id);
        Console.WriteLine($"First organization name: {organization!.Name}");

        return organization.Id;
    }
}