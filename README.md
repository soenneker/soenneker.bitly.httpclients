[![](https://img.shields.io/nuget/v/soenneker.bitly.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bitly.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bitly.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.bitly.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.bitly.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bitly.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bitly.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.bitly.httpclients/actions/workflows/codeql.yml)

# Soenneker.Bitly.HttpClients

Provides a cached, authenticated `HttpClient` for Bitly's v4 API.

## Installation

```bash
dotnet add package Soenneker.Bitly.HttpClients
```

## Configuration

```json
{
  "Bitly": {
    "ApiKey": "your-access-token"
  }
}
```

`Bitly:ApiKey` is required. The defaults are `https://api-ssl.bitly.com/v4/` and `Authorization: Bearer {token}`. `Bitly:ClientBaseUrl`, `Bitly:AuthHeaderName`, and `Bitly:AuthHeaderValueTemplate` can override them.

## Registration

```csharp
using Soenneker.Bitly.HttpClients.Registrars;

services.AddBitlyOpenApiHttpClientAsSingleton();
```

`AddBitlyOpenApiHttpClientAsScoped()` is also available. Both registrations use the singleton HTTP-client cache.

## Usage

```csharp
using Soenneker.Bitly.HttpClients.Abstract;

public sealed class BitlyTransport
{
    private readonly IBitlyOpenApiHttpClient _clientProvider;

    public BitlyTransport(IBitlyOpenApiHttpClient clientProvider)
    {
        _clientProvider = clientProvider;
    }

    public async Task<HttpResponseMessage> Send(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        HttpClient client = await _clientProvider.Get(cancellationToken);
        return await client.SendAsync(request, cancellationToken);
    }
}
```

`Get()` creates the named client on first use and returns it afterward. Configuration changes do not rebuild an existing client. Do not dispose the returned `HttpClient` per request. Disposing the provider removes and disposes its named client from the cache.
