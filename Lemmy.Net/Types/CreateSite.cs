namespace Lemmy.Net.Types
{

    public class CreateSite : IAuthenticable
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
        public List<string> BlockedInstances { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("captcha_difficulty")]
        public string CaptchaDifficulty { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("captcha_enabled")]
        public bool? CaptchaEnabled { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_creation_admin_only")]
        public bool? CommunityCreationAdminOnly { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("default_post_listing_type")]
        public ListingType? DefaultPostListingType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("default_theme")]
        public string DefaultTheme { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("description")]
        public string Description { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("discussion_languages")]
        public List<long> DiscussionLanguages { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enable_downvotes")]
        public bool? EnableDownvotes { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enable_nsfw")]
        public bool? EnableNsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("federation_debug")]
        public bool? FederationDebug { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("federation_enabled")]
        public bool? FederationEnabled { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hide_modlog_mod_names")]
        public bool? HideModlogModNames { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("icon")]
        public string Icon { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("legal_information")]
        public string LegalInformation { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_instance")]
        public bool? PrivateInstance { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_comment")]
        public long? RateLimitComment { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_comment_per_second")]
        public long? RateLimitCommentPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_image")]
        public long? RateLimitImage { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_image_per_second")]
        public long? RateLimitImagePerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_message")]
        public long? RateLimitMessage { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_message_per_second")]
        public long? RateLimitMessagePerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_post")]
        public long? RateLimitPost { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_post_per_second")]
        public long? RateLimitPostPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_register")]
        public long? RateLimitRegister { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_register_per_second")]
        public long? RateLimitRegisterPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_search")]
        public long? RateLimitSearch { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("rate_limit_search_per_second")]
        public long? RateLimitSearchPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("registration_mode")]
        public RegistrationMode RegistrationMode { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("require_email_verification")]
        public bool? RequireEmailVerification { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("sidebar")]
        public string Sidebar { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("slur_filter_regex")]
        public string SlurFilterRegex { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("taglines")]
        public List<string> Taglines { get; set; }

    }
}

