namespace Lemmy.Net.Types
{

    public class CommunityJoinResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("joined")]
        public bool Joined { get; set; }

    }
}

