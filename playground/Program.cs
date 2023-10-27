using BoardsOnFireSdk;
using BoardsOnFireSdk.Exceptions;
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

try
{
    // Organizations
    var firstOrganizationId = await OrganizationsRequests.RunAndReturnFirstOrganizationidAsync(client);

    // Users
    await UsersRequests.RunAsync(client);

    // DataObjects
    // await DataObjectsDynamicRequests.RunAsync(client, firstOrganizationId);
    //await DataObjectsTypedRequests.RunAsync(client, firstOrganizationId);

    //// EntityObjects
    //await EntityObjectsRequests.RunAsync(client, firstOrganizationId);
    await EntityObjectsDynamicRequests.RunAsync(client, firstOrganizationId);
}
catch (BoardsOnFireApiException bofException)
{
    Console.WriteLine(nameof(BoardsOnFireApiException));
    Console.WriteLine($"{nameof(bofException.StatusCode)}: {bofException.StatusCode}");
    Console.WriteLine($"{nameof(bofException.Message)}: {bofException.Message}");
    Console.WriteLine($"{nameof(bofException.ErrorMessage)}: {bofException.ErrorMessage}");
    Console.WriteLine($"{nameof(bofException.InnerException)}: {bofException.InnerException}");
}
catch (Exception e)
{
    Console.WriteLine("Exception:");
    Console.WriteLine(e.Message);
    Console.WriteLine(e.InnerException);
}

Console.WriteLine("Press any key to exit");
Console.ReadKey();