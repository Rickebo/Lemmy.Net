namespace Lemmy.Net.Types
{

    public class PrivateMessageReport
    {
        [System.Text.Json.Serialization.JsonPropertyName("creator_id")]
        public long CreatorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("original_pm_text")]
        public string OriginalPmText { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_message_id")]
        public long PrivateMessageId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("reason")]
        public string Reason { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("resolved")]
        public bool Resolved { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("resolver_id")]
        public long? ResolverId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        public string Updated { get; set; }

    }
}

