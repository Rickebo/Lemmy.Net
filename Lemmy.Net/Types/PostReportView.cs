namespace Lemmy.Net.Types
{

    public class PostReportView
    {
        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("counts")]
        public PostAggregates Counts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator")]
        public Person Creator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator_banned_from_community")]
        public bool CreatorBannedFromCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("my_vote")]
        public long? MyVote { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post")]
        public Post Post { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_creator")]
        public Person PostCreator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_report")]
        public PostReport PostReport { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("resolver")]
        public Person Resolver { get; set; }

    }
}

