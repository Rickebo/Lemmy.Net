namespace Lemmy.Net.Types
{

    public class GetSiteResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("admins")]
        public List<PersonView> Admins { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("all_languages")]
        public List<Language> AllLanguages { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("custom_emojis")]
        public List<CustomEmojiView> CustomEmojis { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("discussion_languages")]
        public List<long> DiscussionLanguages { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("my_user")]
        public MyUserInfo MyUser { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("site_view")]
        public SiteView SiteView { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("taglines")]
        public List<Tagline> Taglines { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("version")]
        public string Version { get; set; }

    }
}

