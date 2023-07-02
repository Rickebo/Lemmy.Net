namespace Lemmy.Net.Types
{

    public class ModBanView
    {
        [System.Text.Json.Serialization.JsonPropertyName("banned_person")]
        public Person BannedPerson { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_ban")]
        public ModBan ModBan { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderator")]
        public Person Moderator { get; set; }

    }
}

