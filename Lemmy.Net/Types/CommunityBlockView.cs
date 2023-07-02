namespace Lemmy.Net.Types
{

    public class CommunityBlockView
    {
        [System.Text.Json.Serialization.JsonPropertyName("community")]
        public Community Community { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person")]
        public Person Person { get; set; }

    }
}

