namespace Lemmy.Net.Types
{

    public class CommentReportResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment_report_view")]
        public CommentReportView CommentReportView { get; set; }

    }
}

