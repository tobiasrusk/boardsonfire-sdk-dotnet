using BoardsOnFireSdk;
using playground;
using playground.RequestsSamples;

Console.WriteLine("Lets Play!");

var playgroundArguments = ArgumentsHelper.GetArgumentsFromEnvironmentVariables();

Console.WriteLine($"Customer Endpoint: '{playgroundArguments.CustomerEndpoint}'. Press any key to continue.");
Console.ReadKey();

var clientBuilder = new BoardsOnFireClient.Builder();
var client = clientBuilder
    .WithApiKeyAuthorization(playgroundArguments.ApiKey)
    .WithCustomerEndpoint(playgroundArguments.CustomerEndpoint)
    .SetUserAgent("Boards on Fire SDK Playground / 1.0")
    .Build();

// Organizations
var firstOrganizationId = await OrganizationsRequests.RunAndReturnFirstOrganizationidAsync(client);

// Users
await UsersRequests.RunAsync(client);

// DataObjects
await DataObjectsRequests.RunAsync(client, firstOrganizationId);

// EntityObjects
await EntityObjectsRequests.RunAsync(client, firstOrganizationId);

Console.WriteLine("Press any key to exit");
Console.ReadKey();