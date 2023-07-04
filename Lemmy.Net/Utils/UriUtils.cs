namespace Lemmy.Net.Utils;

public static class UriUtils
{
    public static Uri GetUri<TContent>(TContent content, params string[] baseUrl)
    {
        var parts = (IEnumerable<string>)baseUrl;
        var uri = GetUri(parts);
        
        var queryString = GetQueryString(content);

        if (queryString == null)
            return uri;
        
        if (!queryString.StartsWith('?'))
            queryString = "?" + queryString;

        var uriString = uri.ToString();
        if (uriString.EndsWith("/"))
            uriString = uriString[..^1];
        
        return new Uri(uriString + queryString);
    }

    public static Uri GetUri(params string?[] parts) =>
        GetUri((IEnumerable<string>)parts);

    public static Uri Append(this Uri uri, string part)
    {
        var str = uri.ToString();
        if (!str.EndsWith("/"))
            str += "/";
        
        return new Uri(str + part);
    }
    
    public static Uri GetUri(IEnumerable<string?> parts) =>
        parts
            .Where(part => part != null)!
            .Aggregate<string, Uri?>(
                null, (current, part) =>
                    current == null
                        ? new Uri(part)
                        : current.Append(part)
            ) ??
        throw new ArgumentException("No valid URI parts were provided.");

    public static string? GetQueryString<TContent>(TContent content) =>
        ReflectionUtils.ToQueryString(content);
}