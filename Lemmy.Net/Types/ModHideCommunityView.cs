namespace Lemmy.Net.Types
{

    public class ModHideCommunityView
    {
        [System.Text.Json.Serialization.JsonPropertyName("admin")]
        public Person Admin { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_hide_community")]
        public ModHideCommunity ModHideCommunity { get; set; }

    }
}

