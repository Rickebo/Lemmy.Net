namespace LemmyApi.Utils;

public static class UriUtils
{
    public static Uri GetUri<TContent>(TContent content, params string[] baseUrl)
    {
        var parts = (IEnumerable<string>)baseUrl;
        var queryString = GetQueryString(content);

        if (queryString != null)
            parts = parts.Concat(new[] { queryString });
        
        return GetUri(parts);
    }

    public static Uri GetUri(params string?[] parts) =>
        GetUri((IEnumerable<string>)parts);

    public static Uri GetUri(IEnumerable<string> parts) =>
        parts
            .Where(part => part != null)!
            .Aggregate<string, Uri?>(
                null, (current, part) =>
                    current == null
                        ? new Uri(part)
                        : new Uri(current, part)
            ) ??
        throw new ArgumentException("No valid URI parts were provided.");

    public static string? GetQueryString<TContent>(TContent content) =>
        ReflectionUtils.ToQueryString(content);
}