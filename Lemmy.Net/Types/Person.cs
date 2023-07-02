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
        string Banner { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("bio")]
        string Bio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("bot_account")]
        bool BotAccount { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deleted")]
        bool Deleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("display_name")]
        string DisplayName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("instance_id")]
        long InstanceId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local")]
        bool Local { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("matrix_user_id")]
        string MatrixUserId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        string Updated { get; set; }

    }
}

