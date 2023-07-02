namespace Lemmy.Net.Types
{

    public class GetCaptchaResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("ok")]
        public CaptchaResponse Ok { get; set; }

    }
}

