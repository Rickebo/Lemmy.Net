using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class PasswordChangeAfterReset
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("password")]
        public string Password { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("password_verify")]
        public string PasswordVerify { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("token")]
        public string Token { get; set; }

    }
}

