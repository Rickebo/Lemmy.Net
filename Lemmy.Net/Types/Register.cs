namespace Lemmy.Net.Types
{

    public class Register
    {
        [System.Text.Json.Serialization.JsonPropertyName("answer")]
        public string Answer { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("captcha_answer")]
        public string CaptchaAnswer { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("captcha_uuid")]
        string CaptchaUuid { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        string Email { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("honeypot")]
        string Honeypot { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("password")]
        string Password { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("password_verify")]
        string PasswordVerify { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_nsfw")]
        bool ShowNsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("username")]
        string Username { get; set; }

    }
}

