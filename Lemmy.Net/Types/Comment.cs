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
        bool Deleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("distinguished")]
        bool Distinguished { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        long Id { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("language_id")]
        long LanguageId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local")]
        bool Local { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("path")]
        string Path { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        long PostId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("published")]
        string Published { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("removed")]
        bool Removed { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("updated")]
        string Updated { get; set; }

    }
}

