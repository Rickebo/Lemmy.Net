namespace Lemmy.Net.Types
{

    public class ModRemoveCommunityView
    {
        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_remove_community")]
        public ModRemoveCommunity ModRemoveCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderator")]
        public Person Moderator { get; set; }

    }
}

