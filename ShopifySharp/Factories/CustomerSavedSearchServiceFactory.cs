#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;

namespace ShopifySharp.Factories;

public interface ICustomerSavedSearchServiceFactory
{
    /// Creates a new instance of the <see cref="ICustomerSavedSearchService" /> with the given credentials.
    /// <param name="shopDomain">The shop's *.myshopify.com URL.</param>
    /// <param name="accessToken">An API access token for the shop.</param>
    ICustomerSavedSearchService Create(string shopDomain, string accessToken);

    /// Creates a new instance of the <see cref="ICustomerSavedSearchService" /> with the given credentials.
    /// <param name="credentials">Credentials for authenticating with the Shopify API.</param>
    ICustomerSavedSearchService Create(ShopifyApiCredentials credentials);
}

public class CustomerSavedSearchServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null) : ICustomerSavedSearchServiceFactory
{
    /// <inheritDoc />
    public virtual ICustomerSavedSearchService Create(string shopDomain, string accessToken)
    {
        var service = new CustomerSavedSearchService(shopDomain, accessToken);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ICustomerSavedSearchService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
