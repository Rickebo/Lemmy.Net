namespace Lemmy.Net.Types
{

    public class BanPerson
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ban")]
        bool Ban { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("expires")]
        long? Expires { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_id")]
        long PersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("reason")]
        string Reason { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("remove_data")]
        bool? RemoveData { get; set; }

    }
}

