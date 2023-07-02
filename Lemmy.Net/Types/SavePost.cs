namespace Lemmy.Net.Types
{

    public class SavePost
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("save")]
        public bool Save { get; set; }

    }
}

