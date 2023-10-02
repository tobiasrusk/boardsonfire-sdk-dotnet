namespace playground;
internal static class ArgumentsHelper
{
    internal static PlaygroundArguments GetArgumentsFromEnvironmentVariables()
    {
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

        return new PlaygroundArguments(apiKey, customerEndpoint);
    }
}
