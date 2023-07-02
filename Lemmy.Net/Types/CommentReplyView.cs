namespace Lemmy.Net.Types
{

    public class CommentReplyView
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment")]
        public Comment Comment { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_reply")]
        public CommentReply CommentReply { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("counts")]
        public CommentAggregates Counts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator")]
        public Person Creator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator_banned_from_community")]
        public bool CreatorBannedFromCommunity { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator_blocked")]
        public bool CreatorBlocked { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("my_vote")]
        public long? MyVote { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post")]
        public Post Post { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("recipient")]
        public Person Recipient { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("saved")]
        public bool Saved { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("subscribed")]
        public SubscribedType Subscribed { get; set; }

    }
}

