using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class DeleteCommunity : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long CommunityId { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

    }
}

