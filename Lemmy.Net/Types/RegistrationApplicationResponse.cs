namespace Lemmy.Net.Types
{

    public class RegistrationApplicationResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("registration_application")]
        public RegistrationApplicationView RegistrationApplication { get; set; }

    }
}

