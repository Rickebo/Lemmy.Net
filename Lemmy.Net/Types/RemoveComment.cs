using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class RemoveComment
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("reason")]
        public string Reason { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("removed")]
        public bool Removed { get; set; }

    }
}

