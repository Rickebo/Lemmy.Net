namespace Lemmy.Net.Types
{

    public class CreateCommentLike : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("score")]
        public long Score { get; set; }

    }
}

