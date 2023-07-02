namespace Lemmy.Net.Types
{

    public class LocalUserView
    {
        [System.Text.Json.Serialization.JsonPropertyName("counts")]
        public PersonAggregates Counts { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("local_user")]
        public LocalUser LocalUser { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("person")]
        public Person Person { get; set; }

    }
}

