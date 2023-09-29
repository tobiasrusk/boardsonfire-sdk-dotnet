using BoardsOnFireSdk;
using BoardsOnFireSdk.Resources;

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
var dataObjects = await client.DataObjects.ListAsync("safety_cross", new ListQuery(50, 1, "comment asc", null, "comment, id, status", ""));
Console.WriteLine($"Fetched dataObjects count: {dataObjects.Count}");

var dataObjectId = (string)((dynamic)dataObjects[0]).id;
var dataObjectGuid = Guid.Parse(dataObjectId);
var dataObject = await client.DataObjects.GetByIdAsync("safety_cross", dataObjectGuid);
Console.WriteLine($"Fetched dataObject status: {((dynamic)dataObject!).status}");

// EntityObjects
var entityObjects = await client.EntityObjects.ListAsync("projekt_enty", new ListQuery(50, 1, "name asc", null, "name, id, status", ""));
Console.WriteLine($"Fetched entityObjects count: {dataObjects.Count}");

var entityObjectId = (string)((dynamic)entityObjects[0]).id;
var entityObjectGuid = Guid.Parse(entityObjectId);
var entityObject = await client.EntityObjects.GetByIdAsync("projekt_enty", entityObjectGuid);
Console.WriteLine($"Fetched entityObject name: {((dynamic)entityObject!).name}");

Console.WriteLine("Press any key to exit");
Console.ReadKey();