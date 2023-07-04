using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class TransferCommunity
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long CommunityId { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("person_id")]
        public long PersonId { get; set; }

    }
}

