namespace Lemmy.Net.Types
{

    public class GetRepliesResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("replies")]
        public List<CommentReplyView> Replies { get; set; }

    }
}

