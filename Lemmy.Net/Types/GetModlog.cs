namespace Lemmy.Net.Types
{

    public class GetModlog : IPaginatedResult
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long? CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public long? Limit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_person_id")]
        public long? ModPersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("other_person_id")]
        public long? OtherPersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("page")]
        public long? Page { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type_")]
        public ModlogActionType Type { get; set; }

    }
}

