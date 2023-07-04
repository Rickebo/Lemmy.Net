using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class DeletePrivateMessage : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("private_message_id")]
        public long PrivateMessageId { get; set; }

    }
}

