namespace Lemmy.Net.Types
{

    public class SearchResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("comments")]
        public List<CommentView> Comments { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("communities")]
        public List<CommunityView> Communities { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("posts")]
        public List<PostView> Posts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("type_")]
        public SearchType Type { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("users")]
        public List<PersonView> Users { get; set; }

    }
}

