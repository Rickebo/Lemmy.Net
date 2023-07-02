namespace Lemmy.Net.Types
{

    public class GetPersonMentionsResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("mentions")]
        public List<PersonMentionView> Mentions { get; set; }

    }
}

