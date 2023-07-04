using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class CreatePrivateMessage : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("content")]
        public string Content { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("recipient_id")]
        public long RecipientId { get; set; }

    }
}

