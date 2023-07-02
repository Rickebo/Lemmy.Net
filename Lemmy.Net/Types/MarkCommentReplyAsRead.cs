namespace Lemmy.Net.Types
{

    public class MarkCommentReplyAsRead
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_reply_id")]
        public long CommentReplyId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("read")]
        public bool Read { get; set; }

    }
}

