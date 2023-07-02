namespace Lemmy.Net.Types
{

    public class BanFromCommunity : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ban")]
        public bool Ban { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("expires")]
        public long? Expires { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_id")]
        public long PersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("reason")]
        public string Reason { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("remove_data")]
        public bool? RemoveData { get; set; }

    }
}

