namespace Lemmy.Net.Types
{

    public class Language
    {
        [System.Text.Json.Serialization.JsonPropertyName("code")]
        public string Code { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

    }
}

