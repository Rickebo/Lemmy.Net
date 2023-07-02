namespace Lemmy.Net.Types
{

    public class ResolveObjectResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment")]
        public CommentView Comment { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public CommunityView Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person")]
        public PersonView Person { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post")]
        public PostView Post { get; set; }

    }
}

