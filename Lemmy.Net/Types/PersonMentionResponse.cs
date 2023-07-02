namespace Lemmy.Net.Types
{

    public class PersonMentionResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("person_mention_view")]
        public PersonMentionView PersonMentionView { get; set; }

    }
}

