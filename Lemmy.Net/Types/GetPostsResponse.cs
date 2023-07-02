namespace Lemmy.Net.Types
{

    public class GetPostsResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("posts")]
        public List<PostView> Posts { get; set; }

    }
}

