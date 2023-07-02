namespace Lemmy.Net.Types
{

    public class ListRegistrationApplicationsResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("registration_applications")]
        public List<RegistrationApplicationView> RegistrationApplications { get; set; }

    }
}

