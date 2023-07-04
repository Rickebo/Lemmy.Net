using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Web;
using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Utils;

public static class ReflectionUtils
{
    private static readonly ThreadLocal<Dictionary<Type, TypeCache>> PropertyCache =
        new(
            () => new Dictionary<Type, TypeCache>()
        );

    /// <summary>
    /// Validates that all properties marked with the <see cref="RequiredAttribute"/> are not null.
    /// </summary>
    /// <param name="body">
    /// The object to validate.
    /// </param>
    /// <typeparam name="TBody">
    /// The type of the object to validate.
    /// </typeparam>
    /// <exception cref="MissingRequiredPropertyException">
    /// Thrown when a required property is null.
    /// </exception>
    public static void Validate<TBody>(TBody body)
    {
        var typeCache = GetTypeCache<TBody>();

        foreach (var property in typeCache.Properties)
        {
            var value = property.GetValue(body);
            if (value != null) 
                continue;
            
            if (!typeCache.RequiredAttributes.TryGetValue(property, out _))
                continue;

            throw new MissingRequiredPropertyException(
                typeof(TBody),
                property.Name,
                $"The {property.Name} ({typeCache.GetSerializedName(property)}) property is required."
            );
        }
    }

    public static string? ToQueryString<TBody>(TBody body)
    {
        var typeCache = GetTypeCache<TBody>();

        var queryAttributes = HttpUtility.ParseQueryString("");

        foreach (var property in typeCache.Properties)
        {
            var value = property.GetValue(body);
            if (value == null)
                continue;

            var serializedName = typeCache.GetSerializedName(property);

            queryAttributes.Add(
                serializedName,
                Convert.ToString(value)
            );
        }


        return queryAttributes.ToString();
    }

    private static TypeCache GetTypeCache<T>() =>
        PropertyCache.Value!.TryGetValue(typeof(T), out var props)
            ? props
            : PropertyCache.Value[typeof(T)] = new TypeCache(typeof(T));

    private class TypeCache
    {
        public PropertyInfo[] Properties { get; }
        public Dictionary<PropertyInfo, string> PropertyNames { get; }
        public Dictionary<PropertyInfo, RequiredPropertyAttribute> RequiredAttributes { get; }

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

            RequiredAttributes = Properties
                .Select(prop => (prop, prop.GetCustomAttribute<RequiredPropertyAttribute>()))
                .Where(pair => pair.Item2 != null)
                .ToDictionary(
                    pair => pair.Item1,
                    pair => pair.Item2!
                );
        }

        public bool IsRequired(PropertyInfo property) => RequiredAttributes.ContainsKey(property);

        public string GetSerializedName(PropertyInfo property) =>
            PropertyNames.TryGetValue(property, out var name)
                ? name
                : property.Name;
    }
}