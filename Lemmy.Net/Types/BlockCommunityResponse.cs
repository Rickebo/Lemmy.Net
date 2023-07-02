namespace Lemmy.Net.Types
{

    public class BlockCommunityResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("blocked")]
        public bool Blocked { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_view")]
        public CommunityView CommunityView { get; set; }

    }
}

