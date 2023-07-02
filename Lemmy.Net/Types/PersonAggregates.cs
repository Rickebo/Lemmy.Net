namespace Lemmy.Net.Types
{

    public class PersonAggregates
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment_count")]
        public long CommentCount { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_score")]
        public long CommentScore { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_id")]
        public long PersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_count")]
        public long PostCount { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_score")]
        public long PostScore { get; set; }

    }
}

