namespace Lemmy.Net.Types
{

    public class GetPost
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_id")]
        public long? CommentId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long? Id { get; set; }

    }
}

