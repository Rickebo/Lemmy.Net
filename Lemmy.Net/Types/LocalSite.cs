namespace Lemmy.Net.Types
{

    public class LocalSite
    {
        [System.Text.Json.Serialization.JsonPropertyName("actor_name_max_length")]
        public long ActorNameMaxLength { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("application_email_admins")]
        public bool ApplicationEmailAdmins { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("application_question")]
        public string ApplicationQuestion { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("captcha_difficulty")]
        public string CaptchaDifficulty { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("captcha_enabled")]
        public bool CaptchaEnabled { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community_creation_admin_only")]
        public bool CommunityCreationAdminOnly { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("default_post_listing_type")]
        public ListingType DefaultPostListingType { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("default_theme")]
        public string DefaultTheme { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enable_downvotes")]
        public bool EnableDownvotes { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("enable_nsfw")]
        public bool EnableNsfw { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("federation_enabled")]
        public bool FederationEnabled { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("hide_modlog_mod_names")]
        public bool HideModlogModNames { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("legal_information")]
        public string LegalInformation { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("private_instance")]
        public bool PrivateInstance { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("registration_mode")]
        public RegistrationMode RegistrationMode { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("reports_email_admins")]
        public bool ReportsEmailAdmins { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("require_email_verification")]
        public bool RequireEmailVerification { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("site_id")]
        public long SiteId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("site_setup")]
        public bool SiteSetup { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("slur_filter_regex")]
        public string SlurFilterRegex { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        public string Updated { get; set; }

    }
}

