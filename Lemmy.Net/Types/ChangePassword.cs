namespace Lemmy.Net.Types
{

    public class ChangePassword : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("new_password")]
        public string NewPassword { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("new_password_verify")]
        public string NewPasswordVerify { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("old_password")]
        public string OldPassword { get; set; }

    }
}

