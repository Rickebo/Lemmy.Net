namespace Lemmy.Net.Types
{

    public class GetPersonMentions : IPaginatedResult
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public long? Limit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("page")]
        public long? Page { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sort")]
        public CommentSortType Sort { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unread_only")]
        public bool? UnreadOnly { get; set; }

    }
}

