namespace Lemmy.Net.Types
{

    public class LeaveAdmin : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

    }
}

