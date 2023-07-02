namespace Lemmy.Net.Types
{

    public class ModBan
    {
        [System.Text.Json.Serialization.JsonPropertyName("banned")]
        public bool Banned { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("expires")]
        public string Expires { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_person_id")]
        public long ModPersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("other_person_id")]
        public long OtherPersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("reason")]
        public string Reason { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("when_")]
        string When { get; set; }

    }
}

