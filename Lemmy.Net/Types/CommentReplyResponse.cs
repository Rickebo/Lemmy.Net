namespace Lemmy.Net.Types
{

    public class CommentReplyResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment_reply_view")]
        public CommentReplyView CommentReplyView { get; set; }

    }
}

