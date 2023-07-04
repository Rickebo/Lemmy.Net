namespace Lemmy.Net.Types.Attributes;

public class MissingRequiredPropertyException : Exception
{
    public Type ObjectType { get; }
    public string PropertyName { get; }
    
    public MissingRequiredPropertyException(Type objectType, string propertyName, string message) 
        : base(message)
    {
        ObjectType = objectType;
        PropertyName = propertyName;
    }
}