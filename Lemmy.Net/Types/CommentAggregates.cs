namespace Lemmy.Net.Types
{

    public class CommentAggregates
    {
        [System.Text.Json.Serialization.JsonPropertyName("child_count")]
        public long ChildCount { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("downvotes")]
        public long Downvotes { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hot_rank")]
        public long HotRank { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("score")]
        public long Score { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("upvotes")]
        public long Upvotes { get; set; }

    }
}

