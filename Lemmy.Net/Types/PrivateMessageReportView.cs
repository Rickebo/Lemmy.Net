namespace Lemmy.Net.Types
{

    public class PrivateMessageReportView
    {
        [System.Text.Json.Serialization.JsonPropertyName("creator")]
        public Person Creator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_message")]
        public PrivateMessage PrivateMessage { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_message_creator")]
        public Person PrivateMessageCreator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_message_report")]
        public PrivateMessageReport PrivateMessageReport { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("resolver")]
        public Person Resolver { get; set; }

    }
}

