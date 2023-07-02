namespace Lemmy.Net.Types
{

    public class CommunityResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("community_view")]
        public CommunityView CommunityView { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("discussion_languages")]
        public List<long> DiscussionLanguages { get; set; }

    }
}

