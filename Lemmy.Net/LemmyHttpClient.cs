using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Lemmy.Net.Types;
using Lemmy.Net.Utils;

namespace Lemmy.Net;

public class LemmyHttpClient : IDisposable
{
    private const string JsonMediaType = "application/json";
    private const string ApiPath = "/api/v3";
    private const string PictrsPath = "/pictrs/image";

    private readonly string _apiUrl;
    private readonly string? _pictrsUrl;

    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly HttpClient _httpClient;
    private readonly bool _disposeHttpClient;
    protected string? AuthToken { get; set; } = null;

    public LemmyHttpClient(
        string apiUrl,
        Dictionary<string, string>? headers = null,
        string? pictrsUrl = null,
        JsonSerializerOptions? jsonSerializerOptions = null,
        HttpClient? httpClient = null
    )
    {
        var trimmedApiUrl = apiUrl.TrimEnd('/');
        var trimmedPictrsUrl = pictrsUrl?.TrimEnd('/');

        _apiUrl = trimmedApiUrl.EndsWith(ApiPath, StringComparison.OrdinalIgnoreCase)
            ? trimmedApiUrl + "/"
            : trimmedApiUrl + ApiPath + "/";

        _pictrsUrl = trimmedPictrsUrl == null
            ? null
            : trimmedPictrsUrl.EndsWith(PictrsPath, StringComparison.OrdinalIgnoreCase)
                ? trimmedPictrsUrl + "/"
                : trimmedPictrsUrl + PictrsPath + "/";

        _jsonSerializerOptions = jsonSerializerOptions ?? new JsonSerializerOptions();
        _httpClient = httpClient ?? new HttpClient();
        _disposeHttpClient = httpClient is null;
        var version = typeof(LemmyHttpClient).Assembly.GetName().Version?.ToString(3) ?? "unknown";
        _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Lemmy.Net", version));

        if (headers != null)
        {
            foreach (var header in headers)
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }

    public void Authenticate(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public void Dispose()
    {
        if (_disposeHttpClient)
            _httpClient.Dispose();

        GC.SuppressFinalize(this);
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
        ReflectionUtils.Validate(body);

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
            ConstructRequest(method, path, body, destination),
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

        if (!response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
            var error = responseBody;
            try
            {
                using var document = JsonDocument.Parse(responseBody);
                var root = document.RootElement;
                if (root.TryGetProperty("error", out var errorProperty) ||
                    root.TryGetProperty("message", out errorProperty))
                    error = errorProperty.GetString() ?? responseBody;
            }
            catch (JsonException)
            {
                error = "Not JSON: " + responseBody[..Math.Min(responseBody.Length, 50)];
            }

            throw new ApiException(
                $"Request to API failed with status code {response.StatusCode}: {error}",
                error,
                response.StatusCode
            );
        }

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

    protected Task<TReceive?> Post<TReceive>(
        string path,
        CancellationToken cancellationToken = default,
        RequestDestination destination = RequestDestination.Api
    ) => Post<EmptyBody, TReceive>(path, EmptyBody.Instance, cancellationToken, destination);

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
