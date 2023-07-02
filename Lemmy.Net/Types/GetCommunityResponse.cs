namespace Lemmy.Net.Types
{

    public class GetCommunityResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("community_view")]
        public CommunityView CommunityView { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("discussion_languages")]
        public List<long> DiscussionLanguages { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderators")]
        public List<CommunityModeratorView> Moderators { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("site")]
        public Site Site { get; set; }

    }
}

