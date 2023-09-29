using BoardsOnFireSdk.Authorization;
using BoardsOnFireSdk.Resources.DataSources;
using BoardsOnFireSdk.Resources.Organizations;
using BoardsOnFireSdk.Resources.Users;

namespace BoardsOnFireSdk;

public class BoardsOnFireClient
{
    public Users Users { get; }
    public Organizations Organizations { get; }
    public DataObjects DataObjects { get; }
    public EntityObjects EntityObjects { get; }

    private BoardsOnFireClient(HttpClient httpClient, IBoardsOnFireAuthorization authorization, string customerEndpoint, int apiVersion)
    {
        httpClient.BaseAddress = new Uri(BoardsOnFireApiConstants.BoardsOnFireApiBaseUri(customerEndpoint, apiVersion));
        authorization.ApplyTo(httpClient);

        Users = new Users(httpClient);
        Organizations = new Organizations(httpClient);
        DataObjects = new DataObjects(httpClient);
        EntityObjects = new EntityObjects(httpClient);
    }

    /// <summary>
    /// Builder to build a Boards on Fire API client
    /// </summary>
    public sealed class Builder
    {
        private readonly HttpClient HttpClient;
        private IBoardsOnFireAuthorization? Authorization;
        private string? CustomerEndpoint;
        private int ApiVersion;

        /// <summary>
        /// Create BoardsOnFire Client builder.
        /// </summary>
        /// <param name="httpClient">Optional HttpClient to use for HTTP requests.</param>
        public Builder(HttpClient? httpClient = null)
        {
            ApiVersion = BoardsOnFireApiConstants.DefaultApiVersion;
            HttpClient = httpClient ?? new HttpClient();
        }

        /// <summary>
        /// Add authentication with API Key
        /// </summary>
        /// <param name="apiKey">API key</param>
        /// <returns>Updated builder</returns>
        public Builder WithApiKeyAuthorization(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            Authorization = new ApiKeyAuthorization(apiKey.Trim());
            return this;
        }

        /// <summary>
        /// Add customer endpoint as sub domain to Base Uri
        /// </summary>
        /// <param name="customerEndpoint">Customer sub domain for connection to Boards on Fire API</param>
        /// <returns>Updated builder</returns>
        public Builder WithCustomerEndpoint(string customerEndpoint)
        {
            if (string.IsNullOrWhiteSpace(customerEndpoint))
            {
                throw new ArgumentNullException(nameof(customerEndpoint));
            }

            var (isValid, errorMessage) = ValidateCustomerEndpoint(customerEndpoint);
            if (!isValid)
            {
                throw new ArgumentException(errorMessage);
            }

            CustomerEndpoint = customerEndpoint;
            return this;
        }

        /// <summary>
        /// Add header User-Agent
        /// </summary>
        /// <param name="userAgent">User-Agent value. Typically 'Product / Version'</param>
        /// <returns>Updated builder</returns>
        public Builder SetUserAgent(string userAgent)
        {
            if (string.IsNullOrWhiteSpace(userAgent))
            {
                throw new ArgumentNullException(nameof(userAgent));
            }

            return AddHeader("User-Agent", userAgent);
        }

        /// <summary>
        /// Set custom API version for Boards on Fire API
        /// </summary>
        /// <param name="apiVersion">Version number</param>
        /// <returns>Updated builder</returns>
        public Builder SetApiVersion(int apiVersion)
        {
            ApiVersion = apiVersion;
            return this;
        }

        /// <summary>
        /// Builds the new client. Builder is invalid after this.
        /// </summary>
        /// <returns>New client.</returns>
        public BoardsOnFireClient Build()
        {
            if (Authorization == null)
            {
                throw new InvalidOperationException($"{nameof(Authorization)} must be set before build. Use {nameof(WithApiKeyAuthorization)}.");
            }

            if (CustomerEndpoint == null)
            {
                throw new InvalidOperationException($"{nameof(CustomerEndpoint)} must be set before build. Use {nameof(WithCustomerEndpoint)}.");
            }

            return new BoardsOnFireClient(HttpClient, Authorization, CustomerEndpoint, ApiVersion);
        }

        /// <summary>
        /// Create new Boards on Fire client builder
        /// </summary>
        /// <param name="httpClient">Optional httpClient</param>
        /// <returns>New Boards on Fire client builder</returns>
        public static Builder Create(HttpClient? httpClient = null)
        {
            return new Builder(httpClient);
        }

        /// <summary>
        /// Add header for API requests
        /// </summary>
        /// <param name="name">Name of the header</param>
        /// <param name="value">Value of the header</param>
        /// <returns>Updated builder</returns>
        private Builder AddHeader(string name, string value)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            HttpClient.DefaultRequestHeaders.Add(name, value);

            return this;
        }

        private static (bool isValid, string? errorMessage) ValidateCustomerEndpoint(string customerEndpoint)
        {
            var domainValidationRegex = Regexes.DomainValidationRegex();
            if (!domainValidationRegex.IsMatch(customerEndpoint.ToLower()))
            {
                return (false, $"Customer Endpoint cannot contain other characters than a-z, 0-9 and -. Value: '{customerEndpoint}'");
            }

            return (true, null);
        }
    }
}