namespace Lemmy.Net.Types
{

    public class VerifyEmail
    {
        [System.Text.Json.Serialization.JsonPropertyName("token")]
        public string Token { get; set; }

    }
}

