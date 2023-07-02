namespace Lemmy.Net.Types
{

    public class CustomEmojiResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("custom_emoji")]
        public CustomEmojiView CustomEmoji { get; set; }

    }
}

