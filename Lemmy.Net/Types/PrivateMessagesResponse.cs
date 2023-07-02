namespace Lemmy.Net.Types
{

    public class PrivateMessagesResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("private_messages")]
        public List<PrivateMessageView> PrivateMessages { get; set; }

    }
}

