namespace Lemmy.Net.Types
{

    public class AdminPurgeCommunityView
    {
        [System.Text.Json.Serialization.JsonPropertyName("admin")]
        public Person Admin { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("admin_purge_community")]
        public AdminPurgeCommunity AdminPurgeCommunity { get; set; }

    }
}

