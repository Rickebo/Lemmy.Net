namespace Lemmy.Net.Types.Attributes;

public sealed class MissingRequiredPropertyException(
    Type objectType,
    string propertyName,
    string message
) : Exception(message)
{
    public Type ObjectType { get; } = objectType;
    public string PropertyName { get; } = propertyName;
}
