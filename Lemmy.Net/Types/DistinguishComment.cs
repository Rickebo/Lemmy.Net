namespace Lemmy.Net.Types
{

    public class DistinguishComment
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("distinguished")]
        public bool Distinguished { get; set; }

    }
}

