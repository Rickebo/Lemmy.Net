namespace Lemmy.Net.Types
{

    public class Community
    {
        [System.Text.Json.Serialization.JsonPropertyName("actor_id")]
        string ActorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banner")]
        string Banner { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deleted")]
        bool Deleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        string Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hidden")]
        bool Hidden { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("icon")]
        string Icon { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("instance_id")]
        long InstanceId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local")]
        bool Local { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nsfw")]
        bool Nsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("posting_restricted_to_mods")]
        bool PostingRestrictedToMods { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("removed")]
        bool Removed { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("title")]
        string Title { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        string Updated { get; set; }

    }
}

