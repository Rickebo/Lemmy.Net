using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class CreateCommentLike : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("score")]
        public long Score { get; set; }

    }
}

