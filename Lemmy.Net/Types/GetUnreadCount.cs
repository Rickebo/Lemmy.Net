namespace Lemmy.Net.Types
{

    public class GetUnreadCount : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

    }
}

