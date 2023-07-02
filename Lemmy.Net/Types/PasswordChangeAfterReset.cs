namespace Lemmy.Net.Types
{

    public class PasswordChangeAfterReset
    {
        [System.Text.Json.Serialization.JsonPropertyName("password")]
        public string Password { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("password_verify")]
        public string PasswordVerify { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("token")]
        public string Token { get; set; }

    }
}

