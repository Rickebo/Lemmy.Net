using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class MarkPostAsRead
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("read")]
        public bool Read { get; set; }

    }
}

