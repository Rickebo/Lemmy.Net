namespace Lemmy.Net.Types
{

    public class FederatedInstances
    {
        [System.Text.Json.Serialization.JsonPropertyName("allowed")]
        public List<Instance> Allowed { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("blocked")]
        public List<Instance> Blocked { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("linked")]
        public List<Instance> Linked { get; set; }

    }
}

