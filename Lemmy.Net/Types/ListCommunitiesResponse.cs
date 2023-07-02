namespace Lemmy.Net.Types
{

    public class ListCommunitiesResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("communities")]
        public List<CommunityView> Communities { get; set; }

    }
}

