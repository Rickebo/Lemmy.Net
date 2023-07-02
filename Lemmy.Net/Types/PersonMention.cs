namespace Lemmy.Net.Types
{

    public class PersonMention
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("read")]
        public bool Read { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("recipient_id")]
        public long RecipientId { get; set; }

    }
}

