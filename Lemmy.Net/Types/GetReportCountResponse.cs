namespace Lemmy.Net.Types
{

    public class GetReportCountResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment_reports")]
        public long CommentReports { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_id")]
        public long? CommunityId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_reports")]
        public long PostReports { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_message_reports")]
        public long? PrivateMessageReports { get; set; }

    }
}

