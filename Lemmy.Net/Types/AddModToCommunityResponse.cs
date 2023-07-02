namespace Lemmy.Net.Types
{

    public class AddModToCommunityResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("moderators")]
        public List<CommunityModeratorView> Moderators { get; set; }

    }
}

