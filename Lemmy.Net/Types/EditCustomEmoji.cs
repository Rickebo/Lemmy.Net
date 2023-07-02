namespace Lemmy.Net.Types
{

    public class EditCustomEmoji : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("alt_text")]
        public string AltText { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("category")]
        public string Category { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("keywords")]
        public List<string> Keywords { get; set; }

    }
}

