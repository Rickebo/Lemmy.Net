namespace Lemmy.Net.Types
{

    public class UploadImageResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("delete_url")]
        public string? DeleteUrl { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("files")]
        public List<ImageFile> Files { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("msg")]
        public string Msg { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}

