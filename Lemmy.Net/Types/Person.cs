namespace Lemmy.Net.Types
{
    public class Person
    {
        [System.Text.Json.Serialization.JsonPropertyName("actor_id")]
        public string ActorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("admin")]
        public bool Admin { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("ban_expires")]
        public string BanExpires { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banned")]
        public bool Banned { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banner")]
        public string Banner { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("bio")]
        public string Bio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("bot_account")]
        public bool BotAccount { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("instance_id")]
        public long InstanceId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local")]
        public bool Local { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("matrix_user_id")]
        public string MatrixUserId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        public string Updated { get; set; }
    }
}