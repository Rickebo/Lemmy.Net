namespace Lemmy.Net.Types
{

    public class Community
    {
        [System.Text.Json.Serialization.JsonPropertyName("actor_id")]
        public string ActorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banner")]
        public string Banner { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public string Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("icon")]
        public string Icon { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("instance_id")]
        public long InstanceId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local")]
        public bool Local { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nsfw")]
        public bool Nsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("posting_restricted_to_mods")]
        public bool PostingRestrictedToMods { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("removed")]
        public bool Removed { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("title")]
        public string Title { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        public string Updated { get; set; }

    }
}

