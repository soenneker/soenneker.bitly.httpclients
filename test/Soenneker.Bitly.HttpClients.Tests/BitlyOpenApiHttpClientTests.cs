using Soenneker.Bitly.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Bitly.HttpClients.Tests;

[Collection("Collection")]
public sealed class BitlyOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IBitlyOpenApiHttpClient _httpclient;

    public BitlyOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IBitlyOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
