namespace Lemmy.Net.Types
{

    public class PersonView
    {
        [System.Text.Json.Serialization.JsonPropertyName("counts")]
        public PersonAggregates Counts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person")]
        public Person Person { get; set; }

    }
}

