namespace Lemmy.Net.Types
{

    public class ModAddView
    {
        [System.Text.Json.Serialization.JsonPropertyName("mod_add")]
        public ModAdd ModAdd { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("modded_person")]
        public Person ModdedPerson { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderator")]
        public Person Moderator { get; set; }

    }
}

