using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class GetReportCount : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long? CommunityId { get; set; }

    }
}

