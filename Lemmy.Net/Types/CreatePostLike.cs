namespace Lemmy.Net.Types
{

    public class CreatePostLike
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("score")]
        public long Score { get; set; }

    }
}

