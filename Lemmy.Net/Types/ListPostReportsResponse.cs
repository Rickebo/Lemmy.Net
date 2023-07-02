namespace Lemmy.Net.Types
{

    public class ListPostReportsResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("post_reports")]
        public List<PostReportView> PostReports { get; set; }

    }
}

