namespace Lemmy.Net.Types
{

    public class CustomEmojiView
    {
        [System.Text.Json.Serialization.JsonPropertyName("custom_emoji")]
        public CustomEmoji CustomEmoji { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("keywords")]
        public List<CustomEmojiKeyword> Keywords { get; set; }

    }
}

