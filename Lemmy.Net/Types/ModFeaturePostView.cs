namespace Lemmy.Net.Types
{

    public class ModFeaturePostView
    {
        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_feature_post")]
        public ModFeaturePost ModFeaturePost { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderator")]
        public Person Moderator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post")]
        public Post Post { get; set; }

    }
}

