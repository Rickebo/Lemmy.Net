using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Lemmy.Net.Types;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortType
{
    [EnumMember(Value = "Active")]
    Active,

    [EnumMember(Value = "Hot")]
    Hot,

    [EnumMember(Value = "New")]
    New,

    [EnumMember(Value = "Old")]
    Old,

    [EnumMember(Value = "TopDay")]
    TopDay,

    [EnumMember(Value = "TopWeek")]
    TopWeek,

    [EnumMember(Value = "TopMonth")]
    TopMonth,

    [EnumMember(Value = "TopYear")]
    TopYear,

    [EnumMember(Value = "TopAll")]
    TopAll,

    [EnumMember(Value = "MostComments")]
    MostComments,

    [EnumMember(Value = "NewComments")]
    NewComments,

    [EnumMember(Value = "TopHour")]
    TopHour,

    [EnumMember(Value = "TopSixHour")]
    TopSixHour,

    [EnumMember(Value = "TopTwelveHour")]
    TopTwelveHour,

    [EnumMember(Value = "TopThreeMonths")]
    TopThreeMonths,

    [EnumMember(Value = "TopSixMonths")]
    TopSixMonths,

    [EnumMember(Value = "TopNineMonths")]
    TopNineMonths
}