namespace Lemmy.Net.Types
{

    public class PrivateMessageResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("private_message_view")]
        public PrivateMessageView PrivateMessageView { get; set; }

    }
}

