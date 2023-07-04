using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class SaveComment
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("save")]
        public bool Save { get; set; }

    }
}

