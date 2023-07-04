using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class Search : IAuthenticable, IPaginatedResult
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long? CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_name")]
        public string CommunityName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator_id")]
        public long? CreatorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public long? Limit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("listing_type")]
        public ListingType? ListingType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("page")]
        public long? Page { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("q")]
        public string Query { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sort")]
        public SortType? Sort { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type_")]
        public SearchType? Type { get; set; }

    }
}

