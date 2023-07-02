namespace Lemmy.Net.Types
{

    public class SaveUserSettings
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("avatar")]
        public string Avatar { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banner")]
        public string Banner { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("bio")]
        public string Bio { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("bot_account")]
        public bool? BotAccount { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("default_listing_type")]
        public ListingType? DefaultListingType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("default_sort_type")]
        public SortType? DefaultSortType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("discussion_languages")]
        public List<long> DiscussionLanguages { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public string Email { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("generate_totp_2fa")]
        public bool? GenerateTotp2fa { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("class_language")]
        public string classLanguage { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("matrix_user_id")]
        public string MatrixUserId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("send_notifications_to_email")]
        public bool? SendNotificationsToEmail { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_avatars")]
        public bool? ShowAvatars { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_bot_accounts")]
        public bool? ShowBotAccounts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_new_post_notifs")]
        public bool? ShowNewPostNotifs { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_nsfw")]
        public bool? ShowNsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_read_posts")]
        public bool? ShowReadPosts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_scores")]
        public bool? ShowScores { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("theme")]
        public string Theme { get; set; }

    }
}

