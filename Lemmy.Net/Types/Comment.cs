namespace Lemmy.Net.Types
{

    public class Comment
    {
        [System.Text.Json.Serialization.JsonPropertyName("ap_id")]
        public string ApId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("content")]
        public string Content { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("creator_id")]
        public long CreatorId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("distinguished")]
        public bool Distinguished { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("language_id")]
        public long LanguageId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local")]
        public bool Local { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("path")]
        public string Path { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        public string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("removed")]
        public bool Removed { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        public string Updated { get; set; }

    }
}

