namespace Lemmy.Net.Types
{

    public class CustomEmoji
    {
        [System.Text.Json.Serialization.JsonPropertyName("alt_text")]
        public string AltText { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("category")]
        public string Category { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local_site_id")]
        public long LocalSiteId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("shortcode")]
        public string Shortcode { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        public string Updated { get; set; }

    }
}

