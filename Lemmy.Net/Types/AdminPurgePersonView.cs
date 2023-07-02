namespace Lemmy.Net.Types
{

    public class AdminPurgePersonView
    {
        [System.Text.Json.Serialization.JsonPropertyName("admin")]
        public Person Admin { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("admin_purge_person")]
        public AdminPurgePerson AdminPurgePerson { get; set; }

    }
}

