namespace Lemmy.Net.Types
{

    public class PostView
    {
        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("counts")]
        public PostAggregates Counts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator")]
        Person Creator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator_banned_from_community")]
        bool CreatorBannedFromCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator_blocked")]
        bool CreatorBlocked { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("my_vote")]
        long? MyVote { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post")]
        Post Post { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("read")]
        bool Read { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("saved")]
        bool Saved { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("subscribed")]
        SubscribedType Subscribed { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("unread_comments")]
        long UnreadComments { get; set; }

    }
}

