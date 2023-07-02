using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lemmy.Net.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CommentSortType
{
    [EnumMember(Value = "Hot")]
    Hot,

    [EnumMember(Value = "Top")]
    Top,

    [EnumMember(Value = "New")]
    New,

    [EnumMember(Value = "Old")]
    Old
}