namespace Lemmy.Net.Types
{

    public class DeleteCustomEmojiResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("success")]
        public bool Success { get; set; }

    }
}

