namespace Lemmy.Net.Types
{

    public class LoginResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("jwt")]
        public string Jwt { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("registration_created")]
        public bool RegistrationCreated { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("verify_email_sent")]
        public bool VerifyEmailSent { get; set; }

    }
}

