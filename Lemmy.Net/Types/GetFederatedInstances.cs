namespace Lemmy.Net.Types
{

    public class GetFederatedInstances : IAuthenticable
    {
        [System.Text.Json.Serialization.JsonPropertyName("auth")]
        public string Auth { get; set; }

    }
}

