namespace Lemmy.Net.Types
{

    public class RegistrationApplicationView
    {
        [System.Text.Json.Serialization.JsonPropertyName("admin")]
        public Person Admin { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator")]
        public Person Creator { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator_local_user")]
        public LocalUser CreatorLocalUser { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("registration_application")]
        public RegistrationApplication RegistrationApplication { get; set; }

    }
}

