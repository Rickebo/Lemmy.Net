namespace Lemmy.Net.Types
{

    public class ModRemovePostView
    {
        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_remove_post")]
        public ModRemovePost ModRemovePost { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderator")]
        public Person Moderator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post")]
        public Post Post { get; set; }

    }
}

