namespace Lemmy.Net.Types
{

    public class RegistrationApplication
    {
        [System.Text.Json.Serialization.JsonPropertyName("admin_id")]
        public long? AdminId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("answer")]
        public string Answer { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deny_reason")]
        public string DenyReason { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local_user_id")]
        public long LocalUserId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

    }
}

