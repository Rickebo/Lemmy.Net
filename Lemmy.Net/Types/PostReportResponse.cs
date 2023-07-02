namespace Lemmy.Net.Types
{

    public class PostReportResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("post_report_view")]
        public PostReportView PostReportView { get; set; }

    }
}

