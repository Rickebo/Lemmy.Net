namespace Lemmy.Net.Types
{

    public class CreatePrivateMessage
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("content")]
        public string Content { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("recipient_id")]
        public long RecipientId { get; set; }

    }
}

