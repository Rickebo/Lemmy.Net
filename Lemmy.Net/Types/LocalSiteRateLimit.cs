namespace Lemmy.Net.Types
{

    public class LocalSiteRateLimit
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment")]
        public long Comment { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_per_second")]
        public long CommentPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("image")]
        public long Image { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("image_per_second")]
        public long ImagePerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local_site_id")]
        public long LocalSiteId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("message")]
        public long Message { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("message_per_second")]
        public long MessagePerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post")]
        public long Post { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_per_second")]
        public long PostPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("register")]
        public long Register { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("register_per_second")]
        public long RegisterPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("search")]
        public long Search { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("search_per_second")]
        public long SearchPerSecond { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        public string Updated { get; set; }

    }
}

