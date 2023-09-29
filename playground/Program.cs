using BoardsOnFireSdk;

Console.WriteLine("Lets Play!");

var apiKey = Environment.GetEnvironmentVariable("BOF_API_KEY");
var customerEndpoint = Environment.GetEnvironmentVariable("BOF_CUSTOMER_ENDPOINT");

if (apiKey == null)
{
    throw new ArgumentException(nameof(apiKey));
}

if (customerEndpoint == null)
{
    throw new ArgumentException(nameof(customerEndpoint));
}

var clientBuilder = new BoardsOnFireClient.Builder();
var client = clientBuilder
    .WithApiKeyAuthorization(apiKey)
    .WithCustomerEndpoint(customerEndpoint)
    .SetUserAgent("Boards on Fire SDK Playground / 1.0")
    .Build();

var organizations = await client.Organizations.ListAsync();
Console.WriteLine($"Fetched organizations count: {organizations.Count}");

var users = await client.Users.ListAsync();
Console.WriteLine($"Fetched users count: {users.Count}");

Console.WriteLine("Press any key to exit");
Console.ReadKey();