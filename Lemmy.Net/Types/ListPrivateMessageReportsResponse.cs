namespace Lemmy.Net.Types
{

    public class ListPrivateMessageReportsResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("private_message_reports")]
        public List<PrivateMessageReportView> PrivateMessageReports { get; set; }

    }
}

