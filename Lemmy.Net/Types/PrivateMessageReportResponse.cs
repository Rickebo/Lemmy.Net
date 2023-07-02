namespace Lemmy.Net.Types
{

    public class PrivateMessageReportResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("private_message_report_view")]
        public PrivateMessageReportView PrivateMessageReportView { get; set; }

    }
}

