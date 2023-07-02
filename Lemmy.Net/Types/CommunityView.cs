namespace Lemmy.Net.Types
{

    public class CommunityView
    {
        [System.Text.Json.Serialization.JsonPropertyName("blocked")]
        public bool Blocked { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("counts")]
        public CommunityAggregates Counts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("subscribed")]
        public SubscribedType Subscribed { get; set; }

    }
}

