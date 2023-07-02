namespace Lemmy.Net.Types
{

    public class ListCommunities : IAuthenticable, IPaginatedResult
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("limit")]
        public long? Limit { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("page")]
        public long? Page { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sort")]
        public SortType? Sort { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type_")]
        public ListingType? Type { get; set; }

    }
}

