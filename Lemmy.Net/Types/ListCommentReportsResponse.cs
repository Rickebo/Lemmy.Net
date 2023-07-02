namespace Lemmy.Net.Types
{

    public class ListCommentReportsResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment_reports")]
        public List<CommentReportView> CommentReports { get; set; }

    }
}

