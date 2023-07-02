namespace Lemmy.Net.Types
{

    public class AdminPurgePostView
    {
        [System.Text.Json.Serialization.JsonPropertyName("admin")]
        public Person Admin { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("admin_purge_post")]
        public AdminPurgePost AdminPurgePost { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

    }
}

