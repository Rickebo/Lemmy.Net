namespace Lemmy.Net.Types
{

    public class MarkPersonMentionAsRead
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_mention_id")]
        public long PersonMentionId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("read")]
        public bool Read { get; set; }

    }
}

