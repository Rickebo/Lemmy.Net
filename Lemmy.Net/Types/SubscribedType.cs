using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lemmy.Net.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]  
public enum SubscribedType
{
    [EnumMember(Value = "Subscribed")]
    Subscribed,

    [EnumMember(Value = "NotSubscribed")]
    NotSubscribed,

    [EnumMember(Value = "Pending")]
    Pending
}