using System.Text.Json.Serialization;

namespace Lemmy.Net.Types
{

    public class ImageFile
    {
        [System.Text.Json.Serialization.JsonPropertyName("delete_token")]
        public string DeleteToken { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("file")]
        public string File { get; set; }

        [JsonIgnore]
        public Uri Url { get; set; }
    }
}

