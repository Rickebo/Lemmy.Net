using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class EditPrivateMessage : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("content")]
        public string Content { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("private_message_id")]
        public long PrivateMessageId { get; set; }

    }
}

