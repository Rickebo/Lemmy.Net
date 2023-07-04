using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class ResolvePrivateMessageReport
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("report_id")]
        public long ReportId { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("resolved")]
        public bool Resolved { get; set; }

    }
}

