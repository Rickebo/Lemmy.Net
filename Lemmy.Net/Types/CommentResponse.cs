namespace Lemmy.Net.Types
{

    public class CommentResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("comment_view")]
        public CommentView CommentView { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("form_id")]
        public string FormId { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("recipient_ids")]
        public List<long> RecipientIds { get; set; }

    }
}

