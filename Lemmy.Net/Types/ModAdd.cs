namespace Lemmy.Net.Types
{

    public class ModAdd
    {
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_person_id")]
        public long ModPersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("other_person_id")]
        public long OtherPersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("removed")]
        public bool Removed { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("when_")]
        public string When { get; set; }

    }
}

