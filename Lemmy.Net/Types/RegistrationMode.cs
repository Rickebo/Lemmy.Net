using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lemmy.Net.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RegistrationMode
{
    [EnumMember(Value = "Closed")]
    Closed,

    [EnumMember(Value = "RequireApplication")]
    RequireApplication,

    [EnumMember(Value = "Open")]
    Open
}