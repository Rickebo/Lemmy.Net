using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lemmy.Net.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SearchType
{
    [EnumMember(Value = "All")]
    All,

    [EnumMember(Value = "Comments")]
    Comments,

    [EnumMember(Value = "Posts")]
    Posts,

    [EnumMember(Value = "Communities")]
    Communities,

    [EnumMember(Value = "Users")]
    Users,

    [EnumMember(Value = "Url")]
    Url
}