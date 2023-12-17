#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;

namespace ShopifySharp.Factories;

public interface ICountryServiceFactory
{
    /// Creates a new instance of the <see cref="ICountryService" /> with the given credentials.
    /// <param name="shopDomain">The shop's *.myshopify.com URL.</param>
    /// <param name="accessToken">An API access token for the shop.</param>
    ICountryService Create(string shopDomain, string accessToken);

    /// Creates a new instance of the <see cref="ICountryService" /> with the given credentials.
    /// <param name="credentials">Credentials for authenticating with the Shopify API.</param>
    ICountryService Create(ShopifyApiCredentials credentials);
}

public class CountryServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null) : ICountryServiceFactory
{
    /// <inheritDoc />
    public virtual ICountryService Create(string shopDomain, string accessToken)
    {
        var service = new CountryService(shopDomain, accessToken);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ICountryService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
