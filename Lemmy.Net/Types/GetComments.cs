namespace Lemmy.Net.Types
{

    public class GetComments : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long? CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_name")]
        public string CommunityName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public long? Limit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("max_depth")]
        public long? MaxDepth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("page")]
        public long? Page { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("parent_id")]
        public long? ParentId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long? PostId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("saved_only")]
        public bool? SavedOnly { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sort")]
        public CommentSortType? Sort { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type_")]
        public ListingType? Type { get; set; }

    }
}

