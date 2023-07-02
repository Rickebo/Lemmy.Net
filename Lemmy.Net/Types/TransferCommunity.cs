namespace Lemmy.Net.Types
{

    public class TransferCommunity
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_id")]
        public long PersonId { get; set; }

    }
}

