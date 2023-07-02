namespace Lemmy.Net.Types
{

    public class RemoveCommunity
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("expires")]
        public long? Expires { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("reason")]
        public string Reason { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("removed")]
        public bool Removed { get; set; }

    }
}

