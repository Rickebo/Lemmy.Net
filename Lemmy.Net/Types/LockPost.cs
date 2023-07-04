using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class LockPost
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("locked")]
        public bool Locked { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

    }
}

