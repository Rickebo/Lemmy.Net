namespace Lemmy.Net.Types
{

    public class ModAddCommunityView
    {
        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_add_community")]
        public ModAddCommunity ModAddCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("modded_person")]
        public Person ModdedPerson { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderator")]
        public Person Moderator { get; set; }

    }
}

