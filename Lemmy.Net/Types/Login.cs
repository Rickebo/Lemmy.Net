namespace Lemmy.Net.Types
{

    public class Login
    {
        [System.Text.Json.Serialization.JsonPropertyName("password")]
        public string Password { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totp_2fa_token")]
        public string Totp2faToken { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("username_or_email")]
        public string UsernameOrEmail { get; set; }

    }
}

