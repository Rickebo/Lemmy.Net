namespace Lemmy.Net.Types
{

    public class ModJoinResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("joined")]
        public bool Joined { get; set; }

    }
}

