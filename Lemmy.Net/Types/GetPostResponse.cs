namespace Lemmy.Net.Types
{

    public class GetPostResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("community_view")]
        public CommunityView CommunityView { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("cross_posts")]
        public List<PostView> CrossPosts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderators")]
        public List<CommunityModeratorView> Moderators { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_view")]
        public PostView PostView { get; set; }

    }
}

