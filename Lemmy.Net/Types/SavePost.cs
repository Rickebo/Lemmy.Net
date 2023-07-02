namespace Lemmy.Net.Types
{

    public class SavePost
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        long PostId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("save")]
        bool Save { get; set; }

    }
}

