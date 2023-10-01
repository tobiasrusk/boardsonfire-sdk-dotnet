using BoardsOnFireSdk;
using BoardsOnFireSdk.Resources;
using playground.Entities;

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

// Organizations
var organizations = await client.Organizations.ListAsync();
Console.WriteLine($"Fetched organizations count: {organizations.Count}");

var organization = await client.Organizations.GetByIdAsync(organizations[0].Id);
Console.WriteLine($"First organization name: {organization!.Name}");

// Users
var users = await client.Users.ListAsync();
Console.WriteLine($"Fetched users count: {users.Count}");

var user = await client.Users.GetByIdAsync(users[0].Id);
Console.WriteLine($"First user LastName: {user!.LastName}");

// DataObjects
var dataObjects = await client.DataObjects.ListAsync<SafetyCrossDataObjectDto>("safety_cross", new ListQuery(50, 1, "comment asc", null, "comment, id, status", ""));
Console.WriteLine($"Fetched dataObjects count: {dataObjects.Count}");

var dataObject = await client.DataObjects.GetByIdAsync<SafetyCrossDataObjectDto>("safety_cross", dataObjects[0].Id);
Console.WriteLine($"Fetched dataObject status: {dataObject!.Status}");

// EntityObjects
var entityObjects = await client.EntityObjects.ListAsync<ProjectEntityObjectDto>("projekt_enty", new ListQuery(50, 1, "name asc", null, "name, id, status", ""));
Console.WriteLine($"Fetched entityObjects count: {dataObjects.Count}");

var entityObject = await client.EntityObjects.GetByIdAsync<ProjectEntityObjectDto>("projekt_enty", entityObjects[0].Id);
Console.WriteLine($"Fetched entityObject name: {entityObject!.Name}");

Console.WriteLine("Press any key to exit");
Console.ReadKey();