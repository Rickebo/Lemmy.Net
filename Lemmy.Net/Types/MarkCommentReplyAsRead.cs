using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class MarkCommentReplyAsRead
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("comment_reply_id")]
        public long CommentReplyId { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("read")]
        public bool Read { get; set; }

    }
}

