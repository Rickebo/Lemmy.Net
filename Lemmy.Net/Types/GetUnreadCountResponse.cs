namespace Lemmy.Net.Types
{

    public class GetUnreadCountResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("mentions")]
        public long Mentions { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_messages")]
        public long PrivateMessages { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("replies")]
        public long Replies { get; set; }

    }
}

