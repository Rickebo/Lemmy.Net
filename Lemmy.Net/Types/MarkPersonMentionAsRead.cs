using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class MarkPersonMentionAsRead
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("person_mention_id")]
        public long PersonMentionId { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("read")]
        public bool Read { get; set; }

    }
}

