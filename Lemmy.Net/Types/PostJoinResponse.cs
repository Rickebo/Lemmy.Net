namespace Lemmy.Net.Types
{

    public class PostJoinResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("joined")]
        public bool Joined { get; set; }

    }
}

