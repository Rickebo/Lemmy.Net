namespace Lemmy.Net.Types
{

    public class ModBanFromCommunityView
    {
        [System.Text.Json.Serialization.JsonPropertyName("banned_person")]
        public Person BannedPerson { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_ban_from_community")]
        public ModBanFromCommunity ModBanFromCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderator")]
        public Person Moderator { get; set; }

    }
}

