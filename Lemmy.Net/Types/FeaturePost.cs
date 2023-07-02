namespace Lemmy.Net.Types
{

    public class FeaturePost : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("feature_type")]
        public PostFeatureType FeatureType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("featured")]
        public bool Featured { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

    }
}

