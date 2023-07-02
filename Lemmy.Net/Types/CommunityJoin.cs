namespace Lemmy.Net.Types
{

    public class CommunityJoin
    {
        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long CommunityId { get; set; }

    }
}

