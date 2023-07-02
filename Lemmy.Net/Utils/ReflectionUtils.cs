using System.Reflection;
using System.Web;

namespace LemmyApi.Utils;

public static class ReflectionUtils
{
    private static readonly ThreadLocal<Dictionary<Type, PropertyInfo[]>> PropertyCache =
        new(
            () => new Dictionary<Type, PropertyInfo[]>()
        );

    public static string? ToQueryString<TBody>(TBody body)
    {
        var type = typeof(TBody);
        
        var properties = PropertyCache.Value!.TryGetValue(type, out var props)
            ? props
            : PropertyCache.Value[type] = type.GetProperties(BindingFlags.Public);

        var queryAttributes = HttpUtility.ParseQueryString("");

        foreach (var property in properties)
            queryAttributes.Add(
                property.Name,
                Convert.ToString(property.GetValue(body))
            );

        return queryAttributes.ToString();
    }
}