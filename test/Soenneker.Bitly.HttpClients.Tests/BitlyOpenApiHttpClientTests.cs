using Soenneker.Bitly.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Bitly.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class BitlyOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IBitlyOpenApiHttpClient _httpclient;

    public BitlyOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IBitlyOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
