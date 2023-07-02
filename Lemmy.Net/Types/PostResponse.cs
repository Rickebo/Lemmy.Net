namespace Lemmy.Net.Types
{

    public class PostResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("post_view")]
        public PostView PostView { get; set; }

    }
}

