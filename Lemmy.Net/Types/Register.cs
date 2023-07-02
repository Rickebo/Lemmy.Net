namespace Lemmy.Net.Types
{

    public class Register
    {
        [System.Text.Json.Serialization.JsonPropertyName("answer")]
        public string Answer { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("captcha_answer")]
        public string CaptchaAnswer { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("captcha_uuid")]
        public string CaptchaUuid { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public string Email { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("honeypot")]
        public string Honeypot { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("password")]
        public string Password { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("password_verify")]
        public string PasswordVerify { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_nsfw")]
        public bool ShowNsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("username")]
        public string Username { get; set; }

    }
}

