namespace Lemmy.Net.Types
{

    public class SiteMetadata
    {
        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public string Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("embed_video_url")]
        public string EmbedVideoUrl { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("image")]
        public string Image { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("title")]
        public string Title { get; set; }

    }
}

