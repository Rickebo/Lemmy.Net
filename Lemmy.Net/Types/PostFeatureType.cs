using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lemmy.Net.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PostFeatureType
{
    [EnumMember(Value = "Local")]
    Local,

    [EnumMember(Value = "Community")]
    Community
}