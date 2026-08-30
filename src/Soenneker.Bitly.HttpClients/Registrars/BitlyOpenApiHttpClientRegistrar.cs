using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Bitly.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Bitly.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class BitlyOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IBitlyOpenApiHttpClient"/> as a singleton service backed by the singleton HTTP-client cache.
    /// </summary>
    public static IServiceCollection AddBitlyOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IBitlyOpenApiHttpClient, BitlyOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IBitlyOpenApiHttpClient"/> as a scoped service backed by the singleton HTTP-client cache.
    /// </summary>
    public static IServiceCollection AddBitlyOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IBitlyOpenApiHttpClient, BitlyOpenApiHttpClient>();

        return services;
    }
}
