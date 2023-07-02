namespace Lemmy.Net.Types
{

    public class GetCommentsResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("comments")]
        public List<CommentView> Comments { get; set; }

    }
}

