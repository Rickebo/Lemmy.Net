namespace Lemmy.Net.Types
{

    public class AddModToCommunity : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("added")]
        public bool Added { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_id")]
        public long PersonId { get; set; }

    }
}

