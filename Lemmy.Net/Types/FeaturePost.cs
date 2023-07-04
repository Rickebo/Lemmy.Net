using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class FeaturePost : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("feature_type")]
        public PostFeatureType FeatureType { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("featured")]
        public bool Featured { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

    }
}

