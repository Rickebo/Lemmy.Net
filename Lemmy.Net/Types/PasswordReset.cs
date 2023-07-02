namespace Lemmy.Net.Types
{

    public class PasswordReset
    {
        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public string Email { get; set; }

    }
}

