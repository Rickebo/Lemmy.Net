namespace Lemmy.Net.Types
{

    public class GetUnreadRegistrationApplicationCount : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

    }
}

