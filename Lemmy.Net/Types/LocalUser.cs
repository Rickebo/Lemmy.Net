namespace Lemmy.Net.Types
{

    public class LocalUser
    {
        [System.Text.Json.Serialization.JsonPropertyName("accepted_application")]
        public bool AcceptedApplication { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("default_listing_type")]
        public ListingType? DefaultListingType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("default_sort_type")]
        public SortType? DefaultSortType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email")]
        public string Email { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("email_verified")]
        public bool EmailVerified { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("class_language")]
        public string classLanguage { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_id")]
        public long PersonId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("send_notifications_to_email")]
        public bool SendNotificationsToEmail { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_avatars")]
        public bool ShowAvatars { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_bot_accounts")]
        public bool ShowBotAccounts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_new_post_notifs")]
        public bool ShowNewPostNotifs { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_nsfw")]
        public bool ShowNsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_read_posts")]
        public bool ShowReadPosts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("show_scores")]
        public bool ShowScores { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("theme")]
        public string Theme { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("totp_2fa_url")]
        public string Totp2faUrl { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("validator_time")]
        public string ValidatorTime { get; set; }

    }
}

