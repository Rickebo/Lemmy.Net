using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class Login
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("password")]
        public string Password { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totp_2fa_token")]
        public string? Totp2faToken { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("username_or_email")]
        public string UsernameOrEmail { get; set; }

    }
}

