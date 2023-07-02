namespace Lemmy.Net.Types
{

    public class MyUserInfo
    {
        [System.Text.Json.Serialization.JsonPropertyName("community_blocks")]
        public List<CommunityBlockView> CommunityBlocks { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("discussion_languages")]
        public List<long> DiscussionLanguages { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("follows")]
        public List<CommunityFollowerView> Follows { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local_user_view")]
        public LocalUserView LocalUserView { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderates")]
        public List<CommunityModeratorView> Moderates { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_blocks")]
        public List<PersonBlockView> PersonBlocks { get; set; }

    }
}

