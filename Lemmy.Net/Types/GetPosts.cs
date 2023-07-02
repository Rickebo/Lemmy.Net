namespace Lemmy.Net.Types
{

    public class GetPosts : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long? CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_name")]
        public string CommunityName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public long? Limit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("page")]
        public long? Page { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("saved_only")]
        public bool? SavedOnly { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sort")]
        public SortType? Sort { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type_")]
        public ListingType? Type { get; set; }

    }
}

