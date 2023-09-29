[![GitHub release](https://img.shields.io/github/release/tobiasrusk/boardsonfire-sdk-dotnet.svg)]() [![nuget](https://img.shields.io/nuget/v/BoardsOnFireSdk.svg)](https://www.nuget.org/packages/BoardsOnFireSdk/) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

# Boards on Fire SDK for .NET
Boards on Fire SDK is an asynchronous SDK for easily accessing and develop towards Boards on Fire API.

To be able to connect to Boards on Fire API you must be a customer to [Boards on Fire](https://boardsonfire.com).

**Note**: Boards on Fire SDK is currently in beta and is not yet ready for use

**Note**: Please note that Boards on Fire SDK is an **unofficial** and community driven SDK. Feel free to contribute.

## Installation
Boards on Fire SDK is available as a [NuGet package](https://www.nuget.org/packages/BoardsOnFireSdk/). To install:

Using Package Manager:
```sh
Install-Package BoardsOnFireSdk
```

Using .NET CLI:
```sh
dotnet add package BoardsOnFireSdk
```

In Visual Studio
[Install NuGet in Visual Studio](https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio).

## Usage
Boards on Fire SDK handle authentication with API keys. It also requires you to set your customer endpoint.

One way to use the SDK is to set required variables as environment variables.

Using Shell:
```sh
export BOF_API_KEY="xyz"
export BOF_CUSTOMER_ENDPOINT="zyx"
```

Using Windows Terminal:
```cmd
setx BOF_API_KEY "xyz"
setx BOF_CUSTOMER_ENDPOINT "zyx"
```

All resources are called from BoardsOnFireClient. Needed input for builder:
- `Authorization` - Method for authorization, currently handles API keys
- `Customer Endpoint` - Your customer endpoint

```c#
using BoardsOnFireSdk;

var apiKey = Environment.GetEnvironmentVariable("BOF_API_KEY");
var customerEndpoint = Environment.GetEnvironmentVariable("BOF_CUSTOMER_ENDPOINT");

var clientBuilder = new BoardsOnFireClient.Builder();
var client = clientBuilder.
  .WithApiKeyAuthorization(apiKey)
  .WithCustomerEndpoint(customerEndpoint)
  .SetUserAgent("Boards on Fire SDK Playground / 1.0")
  .Build();

// Client ready to use, for example list organizations:
var organizations = await client.Organizations.ListAsync();
Console.WriteLine($"Fetched organizations count: {organizations.Count}");
```

It is also possible to use its own HttpClient, to be able to configure it as you want.

## License
[MIT](https://github.com/tobiasrusk/boardsonfire-sdk-dotnet/blob/main/LICENSE)
