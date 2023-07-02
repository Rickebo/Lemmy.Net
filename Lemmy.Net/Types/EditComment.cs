namespace Lemmy.Net.Types
{

    public class EditComment : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("comment_id")]
        public long CommentId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("content")]
        public string Content { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("form_id")]
        public string FormId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("language_id")]
        public long? LanguageId { get; set; }

    }
}

