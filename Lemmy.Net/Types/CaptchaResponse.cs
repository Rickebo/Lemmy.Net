namespace Lemmy.Net.Types
{

    public class CaptchaResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("png")]
        public string Png { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("wav")]
        public string Wav { get; set; }

    }
}

