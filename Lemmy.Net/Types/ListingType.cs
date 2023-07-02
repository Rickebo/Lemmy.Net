using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lemmy.Net.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ListingType
{
    [EnumMember(Value = "All")]
    All,

    [EnumMember(Value = "Local")]
    Local,

    [EnumMember(Value = "Subscribed")]
    Subscribed
}