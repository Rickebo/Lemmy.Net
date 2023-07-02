namespace Lemmy.Net.Types
{

    public class Site
    {
        [System.Text.Json.Serialization.JsonPropertyName("actor_id")]
        public string ActorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banner")]
        public string Banner { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public string Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("icon")]
        public string Icon { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("inbox_url")]
        public string InboxUrl { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("instance_id")]
        public long InstanceId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("last_refreshed_at")]
        public string LastRefreshedAt { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_key")]
        public string PrivateKey { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("public_key")]
        public string PublicKey { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sidebar")]
        string Sidebar { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        string Updated { get; set; }

    }
}

