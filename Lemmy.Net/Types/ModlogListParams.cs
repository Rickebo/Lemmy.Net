namespace Lemmy.Net.Types
{

    public class ModlogListParams : IPaginatedResult
    {
        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long? CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hide_modlog_names")]
        public bool HideModlogNames { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public long? Limit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("mod_person_id")]
        public long? ModPersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("other_person_id")]
        public long? OtherPersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("page")]
        public long? Page { get; set; }

    }
}

