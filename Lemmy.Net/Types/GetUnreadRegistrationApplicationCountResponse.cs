namespace Lemmy.Net.Types
{

    public class GetUnreadRegistrationApplicationCountResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("registration_applications")]
        public long RegistrationApplications { get; set; }

    }
}

