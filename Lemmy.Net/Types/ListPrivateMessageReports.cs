using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class ListPrivateMessageReports : IAuthenticable, IPaginatedResult
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public long? Limit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("page")]
        public long? Page { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unresolved_only")]
        public bool? UnresolvedOnly { get; set; }

    }
}

