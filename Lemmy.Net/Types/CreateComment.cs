namespace Lemmy.Net.Types
{

    public class CreateComment
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("content")]
        public string Content { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("form_id")]
        public string FormId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("language_id")]
        public long? LanguageId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("parent_id")]
        public long? ParentId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

    }
}

