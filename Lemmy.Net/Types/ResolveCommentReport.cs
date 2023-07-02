namespace Lemmy.Net.Types
{

    public class ResolveCommentReport
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("report_id")]
        public long ReportId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("resolved")]
        public bool Resolved { get; set; }

    }
}

