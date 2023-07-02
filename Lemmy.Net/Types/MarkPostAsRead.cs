namespace Lemmy.Net.Types
{

    public class MarkPostAsRead
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("read")]
        public bool Read { get; set; }

    }
}

