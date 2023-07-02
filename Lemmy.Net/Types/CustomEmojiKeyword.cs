namespace Lemmy.Net.Types
{

    public class CustomEmojiKeyword
    {
        [System.Text.Json.Serialization.JsonPropertyName("custom_emoji_id")]
        public long CustomEmojiId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("keyword")]
        public string Keyword { get; set; }

    }
}

