namespace Lemmy.Net.Types
{

    public class CommunityFollowerView
    {
        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("follower")]
        public Person Follower { get; set; }

    }
}

