namespace Lemmy.Net.Types
{

    public class Instance
    {
        [System.Text.Json.Serialization.JsonPropertyName("domain")]
        public string Domain { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("software")]
        public string Software { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        public string Updated { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("version")]
        public string Version { get; set; }

    }
}

