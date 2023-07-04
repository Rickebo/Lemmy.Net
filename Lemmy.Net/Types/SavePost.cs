using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class SavePost
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("save")]
        public bool Save { get; set; }

    }
}

