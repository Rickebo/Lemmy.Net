namespace Lemmy.Net.Types
{

    public class AdminPurgePerson
    {
        [System.Text.Json.Serialization.JsonPropertyName("admin_person_id")]
        public long AdminPersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("reason")]
        public string Reason { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("when_")]
        public string When { get; set; }

    }
}

