namespace Lemmy.Net.Types
{

    public class GetBannedPersons : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

    }
}

