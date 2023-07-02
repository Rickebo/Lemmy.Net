namespace Lemmy.Net.Types
{

    public class DeletePost : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("post_id")]
        public long PostId { get; set; }

    }
}

