using Lemmy.Net.Types.Attributes;

namespace Lemmy.Net.Types
{

    public class CreateCommunity : IAuthenticable
    {
        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banner")]
        public string Banner { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public string Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("discussion_languages")]
        public List<long> DiscussionLanguages { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("icon")]
        public string Icon { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("nsfw")]
        public bool? Nsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("posting_restricted_to_mods")]
        public bool? PostingRestrictedToMods { get; set; }

        [RequiredProperty]
        [System.Text.Json.Serialization.JsonPropertyName("title")]
        public string Title { get; set; }

    }
}

