namespace Lemmy.Net.Types
{

    public class GetCaptcha
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

    }
}

