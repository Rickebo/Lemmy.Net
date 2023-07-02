namespace Lemmy.Net.Types
{

    public class AdminPurgeCommentView
    {
        [System.Text.Json.Serialization.JsonPropertyName("admin")]
        public Person Admin { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("admin_purge_comment")]
        public AdminPurgeComment AdminPurgeComment { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post")]
        public Post Post { get; set; }

    }
}

