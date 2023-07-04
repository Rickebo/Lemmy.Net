using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class CreateCustomEmoji : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("alt_text")]
        public string AltText { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("category")]
        public string Category { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("keywords")]
        public List<string> Keywords { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("shortcode")]
        public string Shortcode { get; set; }

    }
}

