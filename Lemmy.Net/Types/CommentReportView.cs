namespace Lemmy.Net.Types
{

    public class CommentReportView
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment")]
        public Comment Comment { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_creator")]
        public Person CommentCreator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_report")]
        public CommentReport CommentReport { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("counts")]
        public CommentAggregates Counts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator")]
        public Person Creator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator_banned_from_community")]
        public bool CreatorBannedFromCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("my_vote")]
        public long? MyVote { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post")]
        public Post Post { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("resolver")]
        public Person Resolver { get; set; }

    }
}

