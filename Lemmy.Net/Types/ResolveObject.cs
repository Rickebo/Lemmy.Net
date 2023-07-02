namespace Lemmy.Net.Types
{

    public class ResolveObject
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("q")]
        public string Q { get; set; }

    }
}

