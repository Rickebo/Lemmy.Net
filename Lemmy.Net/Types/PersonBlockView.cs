namespace Lemmy.Net.Types
{

    public class PersonBlockView
    {
        [System.Text.Json.Serialization.JsonPropertyName("person")]
        public Person Person { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("target")]
        public Person Target { get; set; }

    }
}

