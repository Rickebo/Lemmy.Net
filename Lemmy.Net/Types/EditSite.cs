namespace Lemmy.Net.Types
{

    public class EditSite
    {
        [System.Text.Json.Serialization.JsonPropertyName("actor_name_max_length")]
        public long? ActorNameMaxLength { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("allowed_instances")]
        public List<string> AllowedInstances { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("application_email_admins")]
        public bool? ApplicationEmailAdmins { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("application_question")]
        public string ApplicationQuestion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("banner")]
        public string Banner { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("blocked_instances")]
        List<string> BlockedInstances { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("captcha_difficulty")]
        string CaptchaDifficulty { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("captcha_enabled")]
        bool? CaptchaEnabled { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_creation_admin_only")]
        bool? CommunityCreationAdminOnly { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("default_post_listing_type")]
        ListingType DefaultPostListingType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("default_theme")]
        string DefaultTheme { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        string Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("discussion_languages")]
        List<long> DiscussionLanguages { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enable_downvotes")]
        bool? EnableDownvotes { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enable_nsfw")]
        bool? EnableNsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("federation_debug")]
        bool? FederationDebug { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("federation_enabled")]
        bool? FederationEnabled { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hide_modlog_mod_names")]
        bool? HideModlogModNames { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("icon")]
        string Icon { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("legal_information")]
        string LegalInformation { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_instance")]
        bool? PrivateInstance { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_comment")]
        long? RateLimitComment { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_comment_per_second")]
        long? RateLimitCommentPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_image")]
        long? RateLimitImage { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_image_per_second")]
        long? RateLimitImagePerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_message")]
        long? RateLimitMessage { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_message_per_second")]
        long? RateLimitMessagePerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_post")]
        long? RateLimitPost { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_post_per_second")]
        long? RateLimitPostPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_register")]
        long? RateLimitRegister { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_register_per_second")]
        long? RateLimitRegisterPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_search")]
        long? RateLimitSearch { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_search_per_second")]
        long? RateLimitSearchPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("registration_mode")]
        RegistrationMode RegistrationMode { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("reports_email_admins")]
        bool? ReportsEmailAdmins { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("require_email_verification")]
        bool? RequireEmailVerification { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sidebar")]
        string Sidebar { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("slur_filter_regex")]
        string SlurFilterRegex { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("taglines")]
        List<string> Taglines { get; set; }

    }
}

