namespace Lemmy.Net.Types
{

    public class BlockPersonResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("blocked")]
        public bool Blocked { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person_view")]
        public PersonView PersonView { get; set; }

    }
}

