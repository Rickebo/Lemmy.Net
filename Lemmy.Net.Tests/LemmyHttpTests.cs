using System.Net;
using System.Text;
using System.Text.Json;
using Lemmy.Net.Types;

namespace Lemmy.Net.Tests;

public sealed class LemmyHttpTests
{
    [Test]
    public async Task GetSiteUsesV3RouteAndBearerToken()
    {
        var handler = new RecordingHandler(_ => Json(HttpStatusCode.OK, "{}"));
        using var client = CreateClient(handler);
        client.Authenticate("test-token");

        await client.GetSite();

        Assert.Multiple(() =>
        {
            Assert.That(handler.Request!.Method, Is.EqualTo(HttpMethod.Get));
            Assert.That(handler.Request.RequestUri!.ToString(), Is.EqualTo("https://example.test/api/v3/site"));
            Assert.That(handler.Request.Headers.Authorization?.Scheme, Is.EqualTo("Bearer"));
            Assert.That(handler.Request.Headers.Authorization?.Parameter, Is.EqualTo("test-token"));
        });
    }

    [Test]
    public async Task VersionedBaseUrlIsNotDuplicated()
    {
        var handler = new RecordingHandler(_ => Json(HttpStatusCode.OK, "{}"));
        using var client = new LemmyHttp(
            "https://example.test/api/v3/",
            httpClient: new HttpClient(handler)
        );

        await client.GetSite();

        Assert.That(handler.Request!.RequestUri!.ToString(), Is.EqualTo("https://example.test/api/v3/site"));
    }

    [Test]
    public async Task GetPostsSerializesQueryNamesAndStringEnums()
    {
        var handler = new RecordingHandler(_ => Json(HttpStatusCode.OK, "{\"posts\":[],\"next_page\":null}"));
        using var client = CreateClient(handler);

        await client.GetPosts(new GetPosts { Sort = SortType.NewComments, CommunityName = "dotnet" });

        Assert.That(
            handler.Request!.RequestUri!.Query,
            Is.EqualTo("?sort=NewComments&community_name=dotnet")
        );
    }

    [Test]
    public void GeneratedModelsUseCurrentFieldsAndEnumValues()
    {
        var json = JsonSerializer.Serialize(new Search
        {
            Q = "lemmy",
            Type = SearchType.Communities,
            PostTitleOnly = true
        });

        Assert.That(json, Is.EqualTo("{\"q\":\"lemmy\",\"community_id\":null,\"community_name\":null,\"creator_id\":null,\"type_\":\"Communities\",\"sort\":null,\"listing_type\":null,\"page\":null,\"limit\":null,\"post_title_only\":true}"));
    }

    [TestCase("application/json", "{\"error\":\"invalid_post_title\"}", "invalid_post_title")]
    [TestCase("text/plain", "upstream exploded", "Not JSON: upstream exploded")]
    public void ErrorResponsesPreserveUsefulDetails(string mediaType, string body, string expectedError)
    {
        var handler = new RecordingHandler(_ => new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            Content = new StringContent(body, Encoding.UTF8, mediaType)
        });
        using var client = CreateClient(handler);

        var exception = Assert.ThrowsAsync<ApiException>(async () =>
            await client.CreatePost(new CreatePost { CommunityId = 1, Name = "invalid" }));

        Assert.Multiple(() =>
        {
            Assert.That(exception!.Error, Is.EqualTo(expectedError));
            Assert.That(exception.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        });
    }

    private static LemmyHttp CreateClient(HttpMessageHandler handler) =>
        new("https://example.test", httpClient: new HttpClient(handler));

    private static HttpResponseMessage Json(HttpStatusCode status, string body) => new(status)
    {
        Content = new StringContent(body, Encoding.UTF8, "application/json")
    };

    private sealed class RecordingHandler(Func<HttpRequestMessage, HttpResponseMessage> responder)
        : HttpMessageHandler
    {
        public HttpRequestMessage? Request { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Request = request;
            return Task.FromResult(responder(request));
        }
    }
}
