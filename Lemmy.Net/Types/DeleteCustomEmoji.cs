namespace Lemmy.Net.Types
{

    public class DeleteCustomEmoji : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public long Id { get; set; }

    }
}

