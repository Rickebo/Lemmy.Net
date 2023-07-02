namespace Lemmy.Net.Types
{

    public class UserJoinResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("joined")]
        public bool Joined { get; set; }

    }
}

