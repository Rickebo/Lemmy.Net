namespace Lemmy.Net.Types
{

    public class GetPersonDetailsResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("comments")]
        public List<CommentView> Comments { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("moderates")]
        public List<CommunityModeratorView> Moderates { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_view")]
        public PersonView PersonView { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("posts")]
        public List<PostView> Posts { get; set; }

    }
}

