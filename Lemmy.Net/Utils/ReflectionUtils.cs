using System.Reflection;
using System.Text.Json.Serialization;
using System.Web;

namespace LemmyApi.Utils;

public static class ReflectionUtils
{
    private static readonly ThreadLocal<Dictionary<Type, TypeCache>> PropertyCache =
        new(
            () => new Dictionary<Type, TypeCache>()
        );

    public static string? ToQueryString<TBody>(TBody body)
    {
        var type = typeof(TBody);

        var typeCache = PropertyCache.Value!.TryGetValue(type, out var props)
            ? props
            : PropertyCache.Value[type] = new TypeCache(type);

        var queryAttributes = HttpUtility.ParseQueryString("");

        foreach (var property in typeCache.Properties)
        {
            var value = property.GetValue(body);
            if (value == null)
                continue;

            var propertyName = typeCache.GetPropertyName(property);

            queryAttributes.Add(
                propertyName,
                Convert.ToString(value)
            );
        }


        return queryAttributes.ToString();
    }

    private class TypeCache
    {
        public PropertyInfo[] Properties { get; }
        public Dictionary<PropertyInfo, string> PropertyNames { get; }

        public TypeCache(IReflect type)
        {
            Properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyNames = Properties.ToDictionary(
                prop => prop,
                prop =>
                {
                    var jsonPropertyName = prop.GetCustomAttribute<JsonPropertyNameAttribute>();
                    return jsonPropertyName != null
                        ? jsonPropertyName.Name
                        : prop.Name;
                }
            );
        }

        public string GetPropertyName(PropertyInfo property) =>
            PropertyNames.TryGetValue(property, out var name)
                ? name
                : property.Name;
    }
}