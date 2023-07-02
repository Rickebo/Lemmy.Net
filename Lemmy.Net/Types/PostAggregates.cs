namespace Lemmy.Net.Types
{

    public class PostAggregates
    {
        [System.Text.Json.Serialization.JsonPropertyName("comments")]
        public long Comments { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("downvotes")]
        public long Downvotes { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("featured_community")]
        public bool FeaturedCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("featured_local")]
        public bool FeaturedLocal { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hot_rank")]
        public long HotRank { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hot_rank_active")]
        public long HotRankActive { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("newest_comment_time")]
        public string NewestCommentTime { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("newest_comment_time_necro")]
        public string NewestCommentTimeNecro { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("score")]
        public long Score { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("upvotes")]
        public long Upvotes { get; set; }

    }
}

