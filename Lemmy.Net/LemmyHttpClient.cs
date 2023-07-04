using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Lemmy.Net.Types;
using Lemmy.Net.Utils;

namespace Lemmy.Net;

public class LemmyHttpClient
{
    private const string JsonMediaType = "application/json";
    private const string ApiSuffix = "/api/v3/";
    private const string PictrsSuffix = "/pictrs/image/";

    private readonly string _apiUrl;
    private readonly string? _pictrsUrl;

    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly HttpClient _httpClient;
    protected string? AuthToken { get; set; } = null;

    public LemmyHttpClient(
        string apiUrl,
        Dictionary<string, string>? headers = null,
        string? pictrsUrl = null,
        JsonSerializerOptions? jsonSerializerOptions = null
    )
    {
        var trimmedApiUrl = apiUrl.TrimEnd('/');
        var trimmedPictrsUrl = pictrsUrl?.TrimEnd('/');

        _apiUrl = trimmedApiUrl.EndsWith(ApiSuffix)
            ? trimmedApiUrl
            : trimmedApiUrl + ApiSuffix;

        _pictrsUrl = trimmedPictrsUrl == null || (trimmedPictrsUrl?.EndsWith(PictrsSuffix) ?? false)
            ? trimmedPictrsUrl
            : trimmedPictrsUrl + PictrsSuffix;

        _jsonSerializerOptions = jsonSerializerOptions ?? new JsonSerializerOptions();
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add(
            "User-Agent",
            "Lemmy.Net/0.1"
        );

        if (headers != null)
        {
            foreach (var header in headers)
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }

    private string GetBaseUrl(RequestDestination destination) =>
        destination switch
        {
            RequestDestination.Api => _apiUrl,
            RequestDestination.Pictrs => _pictrsUrl ?? throw new Exception(
                "Cannot use pictrs without a valid URL."
            ),
            _ => throw new ArgumentOutOfRangeException(
                nameof(destination),
                destination,
                null
            )
        };

    private HttpRequestMessage ConstructRequest<TSend>(
        HttpMethod method,
        string path,
        TSend body,
        RequestDestination destination = RequestDestination.Api
    )
    {
        if (AuthToken != null && body is IAuthenticable authenticable)
            authenticable.Auth = AuthToken;
        
        var baseUrl = GetBaseUrl(destination);
        var uri = method == HttpMethod.Get
            ? UriUtils.GetUri(body, baseUrl, path)
            : UriUtils.GetUri(baseUrl, path);

        var content = method == HttpMethod.Get
            ? null
            : new StringContent(
                JsonSerializer.Serialize(
                    body,
                    _jsonSerializerOptions
                ),
                Encoding.UTF8,
                JsonMediaType
            );

        return new HttpRequestMessage(method, uri)
        {
            Content = content
        };
    }


    protected async Task<HttpResponseMessage> Send<TSend>(
        HttpMethod method,
        string path,
        TSend body,
        CancellationToken cancellationToken = default,
        RequestDestination destination = RequestDestination.Api
    ) => await _httpClient
        .SendAsync(
            ConstructRequest(method, path, body),
            cancellationToken
        );

    protected async Task<TReceive?> SendReceive<TSend, TReceive>(
        HttpMethod method,
        string path,
        TSend body,
        CancellationToken cancellationToken = default,
        RequestDestination destination = RequestDestination.Api
    )
    {
        var response = await Send(
            method: method,
            path: path,
            body: body,
            cancellationToken: cancellationToken,
            destination: destination
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TReceive>(
            _jsonSerializerOptions,
            cancellationToken: cancellationToken
        );
    }

    protected async Task<TReceive?> Post<TSend, TReceive>(
        string path,
        TSend body,
        CancellationToken cancellationToken = default,
        RequestDestination destination = RequestDestination.Api
    ) => await SendReceive<TSend, TReceive>(
        method: HttpMethod.Post,
        path: path,
        body: body,
        cancellationToken: cancellationToken,
        destination: destination
    );

    protected async Task<TReceive?> Get<TQuery, TReceive>(
        string path,
        TQuery body,
        CancellationToken cancellationToken = default,
        RequestDestination destination = RequestDestination.Api
    ) => await SendReceive<TQuery, TReceive>(
        method: HttpMethod.Get,
        path: path,
        body: body,
        cancellationToken: cancellationToken,
        destination: destination
    );

    protected async Task<TReceive?> Get<TReceive>(
        string path,
        CancellationToken cancellationToken = default,
        RequestDestination destination = RequestDestination.Api
    ) => await Get<EmptyBody, TReceive>(
        path: path,
        body: EmptyBody.Instance,
        cancellationToken: cancellationToken,
        destination: destination
    );

    protected async Task<TReceive?> Put<TContent, TReceive>(
        string path,
        TContent body,
        CancellationToken cancellationToken = default,
        RequestDestination destination = RequestDestination.Api
    ) => await SendReceive<TContent, TReceive>(
        method: HttpMethod.Put,
        path: path,
        body: body,
        cancellationToken: cancellationToken,
        destination: destination
    );

    protected enum RequestDestination
    {
        Api = 0,
        Pictrs = 1
    }

    protected class EmptyBody
    {
        public static EmptyBody Instance { get; } = new();
    }
}