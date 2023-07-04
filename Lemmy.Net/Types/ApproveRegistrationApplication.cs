using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class ApproveRegistrationApplication : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("approve")]
        public bool Approve { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deny_reason")]
        public string DenyReason { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

    }
}

