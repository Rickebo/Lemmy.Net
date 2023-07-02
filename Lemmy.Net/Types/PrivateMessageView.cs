namespace Lemmy.Net.Types
{

    public class PrivateMessageView
    {
        [System.Text.Json.Serialization.JsonPropertyName("creator")]
        public Person Creator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_message")]
        public PrivateMessage PrivateMessage { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("recipient")]
        public Person Recipient { get; set; }

    }
}

