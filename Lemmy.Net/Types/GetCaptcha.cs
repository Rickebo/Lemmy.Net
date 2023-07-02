namespace Lemmy.Net.Types
{

    public class GetCaptcha : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

    }
}

