namespace Lemmy.Net.Types
{

    public class UserJoin
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

    }
}

