using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class PurgeCommunity
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("reason")]
        public string Reason { get; set; }

    }
}

